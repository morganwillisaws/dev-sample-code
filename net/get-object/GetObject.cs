using Amazon.S3.Util;
using Amazon.S3;
using Amazon;
using Amazon.S3.Model;

public class GetObject
{
    public static void Main(string[] args)
    {
        const string bucketName = "morgansamples3bucket";
        const string keyName = "airports.csv";

        IAmazonS3 s3Client = new AmazonS3Client(RegionEndpoint.USEast1);
        ReadObjectDataAsync(s3Client, bucketName, keyName);
    }

    private static async void ReadObjectDataAsync(IAmazonS3 s3Client, string bucketName, string keyName)
    {
        string responseBody = string.Empty;

        try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                };

                using (GetObjectResponse response = await s3Client.GetObjectAsync(request))
                using (Stream responseStream = response.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    // Assume you have "title" as medata added to the object.
                    string title = response.Metadata["x-amz-meta-title"];
                    string contentType = response.Headers["Content-Type"];

                    Console.WriteLine($"Object metadata, Title: {title}");
                    Console.WriteLine($"Content type: {contentType}");

                    // Retrieve the contents of the file.
                    responseBody = reader.ReadToEnd();

                    // Write the contents of the file to disk.
                    string filePath = $"C:\\Temp\\copy_of_{keyName}";
                }
            }
            catch (AmazonS3Exception e)
            {
                // If the bucket or the object do not exist
                Console.WriteLine($"Error: '{e.Message}'");
            }
    }
}
