using HogWildSystem.DAL;
using HogWildSystem.Entities;
using HogWildSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogWildSystem.BLL
{
    public class WorkingVersionsService
    {
        private readonly HogWildContext? _hogWildContext;

        internal WorkingVersionsService(HogWildContext? hogWildContext)
        {
            _hogWildContext = hogWildContext;
        }

        public WorkingVersionsView? GetWorkingVersion()
        {
            return _hogWildContext.WorkingVersions
                    .Select(wv => new WorkingVersionsView
                    {
                        VersionId = wv.VersionId,
                        Major = wv.Major,
                        Minor = wv.Minor,
                        Build = wv.Build,
                        Revision = wv.Revision,
                        AsOfDate = wv.AsOfDate,
                        Comments = wv.Comments
                    }).FirstOrDefault();
        }

    }
}
