package com.module6;

import software.amazon.awssdk.auth.credentials.ProfileCredentialsProvider;
import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.services.s3.model.Bucket;
import software.amazon.awssdk.services.s3.model.ListBucketsResponse;

import java.util.List;

public class ListBuckets {
    public static void main(String[] args) {
        ProfileCredentialsProvider credentialsProvider = ProfileCredentialsProvider.create();
        Region region = Region.US_EAST_1;
        S3Client s3 = S3Client.builder()
                .region(region)
                .credentialsProvider(credentialsProvider)
                .build();

        printBuckets(s3);
    }

    private static void printBuckets(S3Client s3) {
        ListBucketsResponse buckets = s3.listBuckets();
        System.out.println("Your {s3} buckets are: ");
        for(Bucket bucket : buckets.buckets()) {
            System.out.println(bucket.name());
        }
    }
}
