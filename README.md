# VideoStreamAPI

## Sections 

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

-	Authentication 
-	Connected to an actual Database
-	Swagger page





