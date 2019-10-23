# VideoStreamAPI DAZN - Tech test

## Getting Started

Download .net Core SDK - https://dotnet.microsoft.com/download/dotnet-core/2.1

Clone the repo, open cmd prompt in root directory and run: dotnet build

Once done move into the VideoStreamAPI folder and run: dotnet run

On the local machine navigate to localhost:5000 in a web browser and see the swagger front-end

## Tests

To run the tests, go to the root of the directory and run: dotnet test

## Assumptions

I assumed that the API will allow users to request streams and delete streams, the maximum streams a user can have open at any time is 3, if a user has 3 streams open and requests another, it will be refused.

Users have to be authorized, if an unauthorized user requests a stream a 401 Unauthourized status code  will be returned.

If users request a video that doesn't exist a 204 No Content status code will be returned.

## End-points

Stream controller:

/stream-content - This end-point returns to the user all content available to stream, so they can request a stream using their userId and videoId

/open-stream - Open stream is used to request a new stream, this will check if the user is authorized, if they haven't hit the 3 stream limit and if the content exists in which it will return a stream model containing the streamId
 
/close-stream - Close stream is use to close a currently open stream, this takes streamId as its only input

/all-streams - all streams returns all currently open streams for a user based on userId

Authorization controller: 

/{userId} - This end-point is used to check if a user is authorized 

/{userId}/authorize - If a user isn't authorized they can provide a userId and hit this end-point, as this project is not going in production I haven't implemented authorization properly as this is just a test. 

## Scalability

This application would be scaled horizontally, using containerization technologies such as docker to create the containers and kubernetes for the horizontal scaling, this will allow more containers to be spun up when a lot of users are requesting and deleting streams as and when necessary .

Database technologies such as postgres would also be used as this is featured around high availability and scalability.

## Improvements:

-	Implement proper Authentication 
-	Connected to a Database such as PostGres which is highly available and scalable
- Containerize the project using docker





