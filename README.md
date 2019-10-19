# VideoStreamAPI

## Sections 

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
- 

3. Architecture

4. Flow





