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
                    List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(
                        PlaylistName.Text, username);
                    //throw new Exception("Doom to Boom");
                    PlayList.DataSource = info;
                    PlayList.DataBind();
                },"Playlist Search", "View the requested playlist below");
                
            }
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
            //code to go here
 
        }

        protected void TracksSelectionList_ItemCommand(object sender, 
            ListViewCommandEventArgs e)
        {
            //code to go here
            
        }

    }
}