using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IContentV2
    {
        Task<byte[]> GetFavIcon(string hosterName);

        Task<byte[]> GetFileIcon(string fileName);

        Task<byte[]> GetIcon(string key, int size);

        Task<IconDescriptor> GetIconDescription(string key);
    }
}
