# VideoStreamAPI DAZN - Tech test

## Getting Started

Clone the repo, open cmd prompt and run: dotnet build.

## Tests

To run the tests, go to the root of the directory and run dotnet test.

## Assumptions

I assumed that the API will allow users to request streams and delete streams, the way I have done this is allowing "Authorized users" to 
request stream content, if user's are not authorized all they have to do is call http:/localhost:5000/authorize/{userId}

## End-points

Stream controller:

/stream-content - This end-point returns to the user all content available to stream, so they can request a stream using their userId and videoId

/open-stream - Open stream is used to request a new stream, this will check if the user is authorized, if they haven't hit the 3 stream limit and if
the content exists
 
/close-stream - Close stream is use to close a currently open stream, this takes streamId as its only input

/all-streams - all streams returns all currently open streams for a user based on userId

Authorization controller: 

/{userId} - This end-point is used to check if a user is authorized 

/{userId}/authorize - If a user isn't authorized they can provide a userId and hit this end-point, as this project is not going in production I 
haven't implemented authorization properly as this 


Breakdown: 
I have created an API in c# to manage video streams, a user will request a video using a client_id and video_id, if the user exists, isn't
already streaming 3 videos and the video exists, the user will be allowed a stream until they close the stream.

1. Task / Assumptions

> Build a service in your preferred language that exposes an API which can be
> consumed from any client. This service must check how many video streams a
> given user is watching and prevent a user watching more than 3 video streams
> concurrently.

Assumptions

The service manages how many videos the user is currently watching and is not responsible for streaming any content.

If a user is watching 3 videos and tries to stream another, the service will refuse to allow another stream.

Once the user has stopped a stream the service will record that they have stopped watching and will reduce the number of streams by 1.

2. Setup

Requirements:
- .NET Core 2.1 installation [link]

3. Architecture
	Controllers:
		- VideoController: Users can request to retrieve all available videos, or specifically request a single video from it's Guid VideoId.
		- AuthorizationController: Users can see check if they are authorized or not, and make a request to authorize themselves.
	Services:
		- VideoService: The Video service provides 
	

4. Flow

## Improvements:

-	Implement proper Authentication 
-	Connected to a Database





