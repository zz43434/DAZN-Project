# VideoStreamAPI DAZN - Tech test

## Getting Started

Clone the repo, open cmd prompt and run: dotnet build.

Once running 

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

## Scalability



## Improvements:

-	Implement proper Authentication 
-	Connected to a Database





