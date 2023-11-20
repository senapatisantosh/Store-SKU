# Store-SKU

## Context Diagram
![image](./Context%20diagram.png)


## Tech-stack
1. Front End - Angular HTML, SCSS, Angular Material
2. Backend - (C#, Python)
3. CICD - Github Action, shell scripting
4. Orchestration - Kubernetes, Helm, Docker
5. AWS cloud - AWS EKS, Step function, Lambda, Api gateway, Cloudfront
6. Data Base - Aurora Mysql, DynamoDB, Elastic Search
7. Streaming platform - Apache Kafaka (AWS Managed servie)
8. Monitoring - Grafana

## Design Decesion 
1. Cloud Storage
CSV files are stored in a cost-effective cloud storage solution. Each country's data is placed in a separate bucket.
2. File Metadata Extraction
Extracted metadata includes:
Country Alpha-2 code
Store ID
Store Category (Individual or retail chain, e.g., Walmart, IKEA)
File Size
3. Event Trigger or API Call
An event is triggered from the storage location, or it's done within the same API to retrieve file metadata.
4. Kafka Stream
Kafka is chosen for its streaming capabilities. It facilitates data movement and consumption efficiently.
5. Publishing to Topic
CSV data is read by a consumer group from different storage locations, converted into JSON streams, and published to a topic.
6. Consumer Groups for Analysis
Various consumer groups are created for specific tasks:
Sending data to an Elastic cluster for search queries.
Storing store/country-specific data in a columnar database (PostgreSQL).
Preparing datasets for training models in a particular country.
Generating financial reports and projections.

## Benefits
1. Scalability: Cloud storage accommodates large-scale data while minimizing costs.
2. Efficiency: Kafka streamlines data flow, enhancing the processing pipeline.
3. Flexibility: Consumer groups allow targeted analysis based on specific needs.
4. Optimized Queries: Elastic cluster for efficient and quick search queries.
5. Structured Storage: PostgreSQL for organized and retrievable store/country-specific data.
6. Machine Learning Support: Data preparation for training models in a country-specific context.

## Rough Solution Diagram
![image](./Rough%20Solution%20Diagram.png)