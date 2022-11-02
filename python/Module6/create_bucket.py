import boto3

s3_client = boto3.client('s3', region_name='us-east-1')

def create_bucket(bucket_name):
    s3_client.create_bucket(Bucket=bucket_name, CreateBucketConfiguration={
    'LocationConstraint': 'us-west-2'})

    waiter = s3_client.get_waiter('bucket_exists')
    waiter.wait(Bucket=bucket_name)


create_bucket("<bucket name>")
