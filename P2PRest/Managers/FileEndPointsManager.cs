using P2PRest.Models;

namespace P2PRest.Managers
{
    public class FileEndpointsManager
    {
        private static List<FileEndpoint> _endpoints = new List<FileEndpoint>();

        public IEnumerable<string> GetFileNames()
        {
            List<string> result = new List<string>();
            foreach (FileEndpoint endpoint in _endpoints)
            {
                if (result.Contains(endpoint.FileName))
                {
                    result.Add(endpoint.FileName);
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

        public FileEndpoint DeleteEndpoint(string fileName)
        {
            FileEndpoint foundFileEndpoint = (FileEndpoint)GetEndpoints(fileName);
            if (foundFileEndpoint != null)
            {
                _endpoints.Remove(foundFileEndpoint);
            }
            return foundFileEndpoint;
        }
    }
}
