
using Firebase.Storage;

using System.Threading.Tasks;

namespace Zool.Firebase_Interface
{
    static class Firebase_Storage
    {
        public static FirebaseStorage storage;

        public static void Init()
        {
            storage = FirebaseStorage.Instance;
        }

        public static UploadTask Upload(string path, byte[] data)
        {
            return storage.GetReference(path).PutBytes(data);
        }
        public static UploadTask Upload(string path, byte[] data, StorageMetadata metadata)
        {
            return storage.GetReference(path).PutBytes(data, metadata);
        }

        public static Task GetUrl(string path)
        {
            return storage.GetReference(path).GetDownloadUrlAsync();
        }

    }
}
