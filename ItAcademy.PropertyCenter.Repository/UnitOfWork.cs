﻿using System;
using System.Data.Entity;
using ItAcademy.PropertyCenter.Repository.Contracts;

namespace ItAcademy.PropertyCenter.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private IAnnouncementRepository announcements;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public IAnnouncementRepository Announcements
        {
            get
            {
                return announcements ?? (announcements = new AnnouncementRepository(context));
            }
        }

        public IAgencyRepository Agencies
        {
            get
            {
                return agencies ?? (agencies = new AgencyRepository(context));
            }
        }

        public IAnnouncementTypeRepository AnnouncementTypes
        {
            get
            {
                return announcementTypes ?? (announcementTypes = new AnnouncementTypeRepository(context));
            }
        }

        private bool disposed = false;
        private IAgencyRepository agencies;
        private IAnnouncementTypeRepository announcementTypes;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
