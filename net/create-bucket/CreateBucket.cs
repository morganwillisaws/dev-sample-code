using Amazon.S3;
using Amazon;
using Amazon.S3.Model;

public class CreateBucket
{
    public static void Main(string[] args)
    {
        IAmazonS3 s3Client = new AmazonS3Client(RegionEndpoint.USEast1);
        create(s3Client, "morgansamples3bucket-123456");
    }

    private static async void create(IAmazonS3 s3Client, string bucketName)
    {
        try
        {
            var putBucketRequest = new PutBucketRequest
            {
                BucketName = bucketName,
                UseClientRegion = true,
            };

            var putBucketResponse = await s3Client.PutBucketAsync(putBucketRequest);
            Console.WriteLine("hello");
        }
        catch (AmazonS3Exception ex)
        {
            Console.WriteLine($"Error creating bucket: '{ex.Message}'");
        }
    }
}

