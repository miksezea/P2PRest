using P2PRest.Models;

namespace P2PRest.Repositories
{
    public class FileEndpointsRepository
    {
        private static List<FileEndpoint> _endpoints = new List<FileEndpoint>()
        {
            new FileEndpoint { FileName = "test", IpAddress = "0.0.0.0", Port = 12 },
            new FileEndpoint { FileName = "test", IpAddress = "0.0.0.0", Port = 13 },
            new FileEndpoint { FileName = "test2", IpAddress = "0.0.0.0", Port = 12 }
        };

        public IEnumerable<string> GetFileNames()
        {
            List<string> result = new List<string>();
            foreach (FileEndpoint endpoint in _endpoints)
            {
                if (endpoint.FileName is not null)
                {
                    if (!result.Contains(endpoint.FileName))
                    {
                        result.Add(endpoint.FileName);
                    }
                }

            }
            return result;
        }
        public IEnumerable<FileEndpoint> GetEndpoints(string fileName)
        {
            return _endpoints.FindAll(endpoint => endpoint.FileName.Equals(fileName, StringComparison.InvariantCultureIgnoreCase));
        }
        public FileEndpoint AddEndpoint(FileEndpoint newEndpoint)
        {
            _endpoints.Add(newEndpoint);
            return newEndpoint;
        }
        public FileEndpoint DeleteEndpoint(string fileName, string ipaddress, int port)
        {
            IEnumerable<FileEndpoint> endpoints = GetEndpoints(fileName);
            FileEndpoint foundEndpoint = endpoints.First(endpoint => endpoint.IpAddress == ipaddress && endpoint.Port == port);
            if (foundEndpoint is not null)
            {
                _endpoints.Remove(foundEndpoint);
            }
            return foundEndpoint;
        }
    }
}
