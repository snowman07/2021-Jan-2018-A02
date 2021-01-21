﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using ChinookSystem.BLL;
using ChinookSystem.DAL;
using ChinookSystem.ViewModels;
#endregion

namespace WebApp.SamplePages
{
    public partial class SearchByDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Message.Text = "";
            if(!Page.IsPostBack)
            {
                // this is first time
                LoadArtistList();
            }
        }

        #region Error Handling ODS
        protected void SelectCheckForException(object sender, ObjectDataSourceEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }
        #endregion

        protected void LoadArtistList()
        {
            ArtistController sysmgr = new ArtistController();
            List<SelectionList> info = sysmgr.Artists_DDLList();

            // lets assume the data collection needs to be sort
            info.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField));

            //setup the ddl
            ArtistList.DataSource = info;
            //ArtistList.DataTextField = "DisplayField";
            ArtistList.DataTextField = nameof(SelectionList.DisplayField); //nameof(object.prop)
            ArtistList.DataValueField = nameof(SelectionList.ValueField); //nameof(object.prop)
            ArtistList.DataBind();

            //prompt line
            ArtistList.Items.Insert(0, new ListItem("select...", "0"));
        }

        protected void SearchAlbums_Click(object sender, EventArgs e)
        {
            if(ArtistList.SelectedIndex == 0)
            {
                //index 0 is physically pointing to the prompt line
                //Message.Text = "Select an artist for the search.";
                //using MessageUserControl for your own message
                MessageUserControl.ShowInfo("Search concern.", "Select an artist for the search.");
                ArtistAlbumList.DataSource = null;
                ArtistAlbumList.DataBind();
            }
            else
            {
                //user friendly error handling
                //normally when you leave your web page to your class library,
                //      you will want to have an error handling. (aka try/catch

                //use MessageUserControl to handle errors
                //  MessageUserControl has try/catch embedded inside its
                //  logic

                MessageUserControl.TryRun(() => { 
                    //standard lookup and assignment
                    AlbumController sysmgr = new AlbumController();
                    List<ChinookSystem.ViewModels.ArtistAlbums> info = sysmgr.Albums_GetAlbumsForArtist(
                        int.Parse(ArtistList.SelectedValue));
                    ArtistAlbumList.DataSource = info;
                    ArtistAlbumList.DataBind();
                }, "Success Message title", "Your success messsage goes here");
                
            }
        }
    }
}