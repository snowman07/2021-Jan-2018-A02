﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.DAL;
using ChinookSystem.Entities; // for SQL and are internal
using ChinookSystem.ViewModels; // for data class to transfer data from BLL to webapp
using System.ComponentModel; //for ODS wizard
#endregion

namespace ChinookSystem.BLL
{
    [DataObject] // to expose the class
    public class AlbumController // interface to the outside
    {
        #region Query used for ArtistAlbums.aspx page
        //method to return data to dump or expose to the wizard. Select(query) . False=not the default query
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetArtistAlbums()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name
                                                    };
                return results.ToList();
            }
        }
        #endregion

        #region Query used for SearchByDDL.aspx page
        // -----------------Coded on Jan 15, 2021 Friday Week02(result page is SearchByDDL)
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetAlbumsForArtist(int artistid)
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    where x.ArtistId == artistid
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name,
                                                        ArtistId = x.ArtistId
                                                    };
                return results.ToList();
            }
        }
        #endregion

        #region Queries used for ListViewODSCRUD.aspx page
        //query to return all data of the Album table

        //method to return data to dump or expose to the wizard. Select(query) . False=not the default query
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumItem> Albums_List()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<AlbumItem> results = from x in context.Albums
                                                    select new AlbumItem
                                                    {
                                                        AlbumId = x.AlbumId,
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistId = x.ArtistId,
                                                        ReleaseLabel = x.ReleaseLabel
                                                    };
                return results.ToList();
            }
        }

        //query to look up an Album record by PK
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AlbumItem Albums_FindById(int albumid) //this is just a single record thats why List<> and IEnumerable<> is not used
        {
            using (var context = new ChinookSystemContext())
            {
                //----Feb 10, 2020 lesson----
                //in CPSC1517, when entities were public, we could use 
                //  the entityFramework method extension .Find(xxx)
                //  to retrieve the database record on the primary key
                //  return context.DbSetname.Find(xxx);
                //---------------------------

                // (...).FirstOrDefault will return either
                //      a) the first record matching the where condition
                //      b) a null value
                AlbumItem results = (from x in context.Albums 
                              where x.AlbumId == albumid
                            select new AlbumItem
                            {
                                AlbumId = x.AlbumId,
                                Title = x.Title,
                                ReleaseYear = x.ReleaseYear,
                                ArtistId = x.ArtistId,
                                ReleaseLabel = x.ReleaseLabel
                            }).FirstOrDefault();
                return results;
            }
        }
        #endregion

        #region Add, Update and Delete CRUD

        //Add
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int Album_Add(AlbumItem item) // this will return PK
        {
            using (var context = new ChinookSystemContext())
            {
                //due to the fact that we have separated the handling of our entities
                //      from the data transfer between web app and class library
                //      using the ViewModel classes, we must create an instance
                //      of the entity and move the data from the ViewModel class
                //      to the entity instance
                Album addItem = new Album
                {
                    //why no PK set?
                    //PK is an identity PK, no value is needed
                    //However, if PK is NOT an identity spec(Identity Specification = No in the DB), ADD PK here!!!
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };

                //staging 
                //setup in local memory
                //at this point you will NOT have sent anything to the database
                //      therefore, you will NOT have your new PK as yet
                context.Albums.Add(addItem);

                //commit to database
                //on this command you
                //  a) execute entity validation annotation
                //  b) send your local memory staging to the database for execution
                //after a successful execution, your entity instance will have the 
                //      new PK (Identity) value
                context.SaveChanges();

                //at this point, your entity instance has the new PK value
                return addItem.AlbumId;
            }
        }

        //Update
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Album_Update(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                //due to the fact that we have separated the handling of our entities
                //      from the data transfer between web app and class library
                //      using the ViewModel classes, we must create an instance
                //      of the entity and move the data from the ViewModel class
                //      to the entity instance
                Album updateItem = new Album
                {
                    //for an update, you need to supply your PK value
                    AlbumId = item.AlbumId,
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };

                //staging 
                //setup in local memory

                context.Entry(updateItem).State = System.Data.Entity.EntityState.Modified;

                //commit to database
                //on this command you
                //  a) execute entity validation annotation
                //  b) send your local memory staging to the database for execution
                
                context.SaveChanges();

            }
        }

        //Delete

        //When we do an ODS CRUD on the delete, ODS sends in the entire
        //  instance record, not just the PK value

        //overload the Album_Delete method so it receive a whole instance
        //  then call the actual delete method passing just the
        //  PK value to the actual delete method
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Album_Delete(AlbumItem item)
        {
            Album_Delete(item.AlbumId);
        }

        public void Album_Delete(int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                //example of a physical delete
                //retrieve the current entity instance based on the incoming parameter
                var exists = context.Albums.Find(albumid);
                //staged the remove
                context.Albums.Remove(exists);
                //commit the remove
                context.SaveChanges();

                //a logical delete is actually an update of the instance
            }
        }
        #endregion
    }
}
