using System;
using Microsoft.TeamFoundation.Client;

namespace AutoMerge.Standalone
{
  /// <summary>
  /// Minimal service provider for standalone operation
  /// </summary>
  public class StandaloneServiceProvider : IServiceProvider
  {
    private readonly TfsTeamProjectCollection _tfsConnection;

    public StandaloneServiceProvider(string tfsUrl)
    {
      _tfsConnection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(tfsUrl));
      _tfsConnection.EnsureAuthenticated();
    }

    public object GetService(Type serviceType)
    {
      // Return the TFS connection for TFS-related services
      if (serviceType == typeof(TfsTeamProjectCollection))
      {
        return _tfsConnection;
      }

      // Add more service mappings as needed
      return null;
    }

    public TfsTeamProjectCollection TfsConnection => _tfsConnection;
  }
}
