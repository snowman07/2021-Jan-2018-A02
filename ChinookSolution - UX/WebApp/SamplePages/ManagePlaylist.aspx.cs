﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;

#endregion

namespace WebApp.SamplePages
{
    public partial class ManagePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TracksSelectionList.DataSource = null;
        }

        #region MessageUserControl Error Handling for ODS
        protected void SelectCheckForException(object sender,
            ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }
        protected void InsertCheckForException(object sender,
            ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                MessageUserControl.ShowInfo("Process success", "Album has been added");
            }
            else
            {
                MessageUserControl.HandleDataBoundException(e);
            }

        }
        protected void UpdateCheckForException(object sender,
            ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                MessageUserControl.ShowInfo("Process success", "Album has been updates");
            }
            else
            {
                MessageUserControl.HandleDataBoundException(e);
            }

        }
        protected void DeleteCheckForException(object sender,
            ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                MessageUserControl.ShowInfo("Process success", "Album has been removed");
            }
            else
            {
                MessageUserControl.HandleDataBoundException(e);
            }

        }

        #endregion


        protected void ArtistFetch_Click(object sender, EventArgs e)
        {
            TracksBy.Text = "Artist";
            //the HiddenField content access is .Value NOT .Text
            if (string.IsNullOrEmpty(ArtistName.Text))
            {
                MessageUserControl.ShowInfo("You did not supply an artist name.");
                //the HiddenField content access is .Value NOT .Text
                SearchArg.Value = "zxcvg";
            }
            else
            {
                //the HiddenField content access is .Value NOT .Text
                SearchArg.Value = ArtistName.Text;
            }
            // to force the re-execution of an ODS attached to a display control
            //      rebind the display control
            TracksSelectionList.DataBind();
        }


        protected void GenreFetch_Click(object sender, EventArgs e)
        {
            TracksBy.Text = "Genre";
            //the HiddenField content access is .Value NOT .Text
            //if (string.IsNullOrEmpty(ArtistName.Text))
            //{
            //    MessageUserControl.ShowInfo("You did not supply an artist name.");
            //the HiddenField content access is .Value NOT .Text
            //    SearchArg.Value = "zxcvg";
            //}
            //else
            //{
            //    //the HiddenField content access is .Value NOT .Text
            //    SearchArg.Value = ArtistName.Text;
            //}


            ////----APPLICABLE TO ONE AND SECOND WAY TO DISPLAY RESULTS OF GENRE, ALBUM and ARTIST (found in TrackController)
            //// if you had a prompt in your ddl, you would verify that a
            ////      selection was made
            //// you could use the value field of the dropdownlist
            //SearchArg.Value = GenreDDL.SelectedValue;
            ////----ENDOF APPLICABLE TO ONE AND SECOND WAY TO DISPLAY RESULTS OF GENRE, ALBUM and ARTIST (found in TrackController)

            ////---------THIRD WAY TO DISPLAY RESULTS OF GENRE, ALBUM and ARTIST using SelectedItem
            // Can I use something else from the ddl instead of the value field???
            // there is the display field
            // WARNING: using the display field for the local, in this example, is possible
            //      bec EACH description is unique!!!!
            SearchArg.Value = GenreDDL.SelectedItem.Text;
            ////---------ENDOF THIRD WAY TO DISPLAY RESULTS OF GENRE, ALBUM and ARTIST using SelectedItem



            // to force the re-execution of an ODS attached to a display control
            //      rebind the display control
            TracksSelectionList.DataBind();
        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            TracksBy.Text = "Album";
            //the HiddenField content access is .Value NOT .Text
            if (string.IsNullOrEmpty(AlbumTitle.Text))
            {
                MessageUserControl.ShowInfo("You did not supply an album title.");
                //the HiddenField content access is .Value NOT .Text
                SearchArg.Value = "zxcvg";
            }
            else
            {
                //the HiddenField content access is .Value NOT .Text
                SearchArg.Value = AlbumTitle.Text;
            }
            // to force the re-execution of an ODS attached to a display control
            //      rebind the display control
            TracksSelectionList.DataBind();
        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
            //username is coming from the system via security
            //since security has yet to be installed, a default will be setup for the 
            //      username value
            string username = "HansenB";
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Playlist Search", "No playlist name was supplied.");
            }
            else
            {
                //use some user friendly error handling
                //the way we are doing the error handling is using MessageUserControl instead
                //  of try/catch
                //MessageUserControl has the try/catch embedded within the control logic
                //within the MessageUserControl there exists a method called. TryRun() syntax
                //  MessageUserControl.TryRun(() => {
                //
                //      your coding logic
                //
                //  },["Message Title", "success message"]);
                // FOR THIS PLAYLIST FETCH, THERE'S NO ODS INVOLVED. ITS PURELY CODED IN CODE BEHIND
                MessageUserControl.TryRun(() => { 
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    //List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(
                    RefreshPlayList(sysmgr, username);
                    //throw new Exception("Doom to Boom");
                    //PlayList.DataSource = info;
                    //PlayList.DataBind();
                },"Playlist Search", "View the requested playlist below");
                
            }
        }

        protected void RefreshPlayList(PlaylistTracksController sysmgr, string username)
        {
            List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(
                        PlaylistName.Text, username);
            //throw new Exception("Doom to Boom");
            PlayList.DataSource = info;
            PlayList.DataBind();
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void MoveTrack(int trackid, int tracknumber, string direction)
        {
            //call BLL to move track
 
        }


        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            string username = "HansenB"; //until security is implemented

            //form event validation: presence
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Missing Data", "Enter a playlist name");
            }
            else
            {
                if (PlayList.Rows.Count == 0)
                {
                    MessageUserControl.ShowInfo("Track Removal", "You must have a playlist visible to choose removals. Select from the displayed playlist.");
                }
                else
                {
                    //collect the tracks indicated on the playlist for removal
                    List<int> trackids = new List<int>();
                    int rowsSelected = 0;
                    CheckBox trackSelection = null;
                    //traverse the gridview control PlayList
                    //you could do this same code using a foreach()
                    for(int i = 0; i < PlayList.Rows.Count; i++)
                    {
                        //point to the checkbox control on the gridview row
                        trackSelection = PlayList.Rows[i].FindControl("Selected") as CheckBox;
                        //test the setting of the checkbox
                        if (trackSelection.Checked)
                        {
                            rowsSelected++;
                            trackids.Add(int.Parse((PlayList.Rows[i].FindControl("TrackId") as Label).Text));

                        }
                    }

                    // was a song selected
                    if (rowsSelected == 0)
                    {
                        MessageUserControl.ShowInfo("Missing Data", "You must select atleast one song to remove.");
                    }
                    else
                    {
                        //data collected, send for processing
                        MessageUserControl.TryRun(() => 
                        {
                            PlaylistTracksController sysmgr = new PlaylistTracksController();
                            sysmgr.DeleteTracks(username, PlaylistName.Text, trackids);
                            RefreshPlayList(sysmgr, username);
                        }, "Track Removal", "Selected track(s) have been removed from the playlist.");

                    }
                }
            }
        }

        protected void TracksSelectionList_ItemCommand(object sender, 
            ListViewCommandEventArgs e)
        {
            string username = "HansenB"; //until security is implemented
            
            //form event validation: presence
            if(string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Missing Data", "Enter a playl;ist name");
            }
            else
            {
                //Reminder: MessageUserControl will do the error handling
                MessageUserControl.TryRun(() => {
                    //logic  for your coding block
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    
                    //access a specific field on the selected ListView row
                    string song = (e.Item.FindControl("NameLabel") as Label).Text;
                    sysmgr.Add_TrackToPLaylist(PlaylistName.Text,
                                                username,
                                                int.Parse(e.CommandArgument.ToString()),
                                                song);
                    RefreshPlayList(sysmgr, username);

                },"Add Track to Playlist", "Track has been added to the playlist.");
            }
        }

    }
}