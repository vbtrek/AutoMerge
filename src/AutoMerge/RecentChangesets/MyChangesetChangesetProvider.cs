using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoMerge
{
  public class MyChangesetChangesetProvider : ChangesetProviderBase
  {
    private readonly int _maxChangesetCount;

    public MyChangesetChangesetProvider(IServiceProvider serviceProvider, int maxChangesetCount)
      : base(serviceProvider)
    {
      _maxChangesetCount = maxChangesetCount;
    }

    public MyChangesetChangesetProvider(ChangesetService changesetService, string teamProjectName, int maxChangesetCount)
      : base(changesetService, teamProjectName)
    {
      _maxChangesetCount = maxChangesetCount;
    }

    protected override List<ChangesetViewModel> GetChangesetsInternal(string userLogin)
    {
      var changesets = new List<ChangesetViewModel>();

      if (!string.IsNullOrEmpty(userLogin))
      {
        var changesetService = GetChangesetService();

        if (changesetService != null)
        {
          var projectName = GetProjectName();

          // TODO_DS1 Worth doubling _maxChangesetCount here

          var tfsChangesets = changesetService.GetUserChangesets(projectName, userLogin, _maxChangesetCount);

          ///*
          changesets = tfsChangesets
            .Select(tfsChangeset => ToChangesetViewModel(tfsChangeset, changesetService))
            .ToList();
          //*/

          // TODO_DS1 Eliminate MERGE changesets, as they are not relevant for AutoMerge
          ///*
          changesets = changesets
            .Where(cs => !cs.Comment.StartsWith("MERGE") || cs.Branches.Count > 1)
            .Take(_maxChangesetCount)
            .ToList();
          //*/
        }
      }

      return changesets;
    }
  }
}
