using Amazon.S3.Util;
using Amazon.S3;
using Amazon;

public class VerifyBucketName
{
    public static void Main(string[] args)
    {
        IAmazonS3 s3Client = new AmazonS3Client(RegionEndpoint.USEast1);
        VerifyBucket(s3Client, "morgansamples3bucket");
    }

    private static async void VerifyBucket(IAmazonS3 s3Client, string bucketName)
    {
        bool exists = false;

        exists = AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName).Result;
        if(exists) {
            Console.WriteLine("This bucket already exists.");
        }
        else 
        {
            Console.WriteLine("The bucket does not exist.");
        }
    }
}
