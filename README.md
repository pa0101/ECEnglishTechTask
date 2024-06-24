# ECEnglishTechTask

## Backend
- NET 8
- Entity Framework Core
- XUnit

## Frontend
- React
- TypeScript
- Vite

## How to use this app
- To start the api, open a terminal and change into BackendECEnglishTechTask.API directory, use command 'dotnet run'. Observe the local host url it's running on.
- To start the React app, check that the api base url setting in the .env.local file has the same value as local host url that's running. Modify it to match if it's different. In the terminal change into Frontend/src directory and use command 'npm run dev'. 
- Navigate to the local url of the React app.

## Booking a Holiday and Extending Course Dates Logic
Input:
- holidayStartDate: Date the holiday starts (must be a Monday)
- holidayEndDate: Date the holiday ends (must be a Friday)
Output:
- List of courses with new start and end dates 

Algorithm:
1. Validate holidayStartDate and holidayEndDate to check they are a Monday and Friday respectively.
2. Get all the start (Monday) and end (Friday) date ranges that are in the holiday break.
3. Calculate the numberOfHolidayWeeks in the holiday break.
4. Find affected course enrollments that match the date ranges in the holiday break, and, include all subsequent course enrollments after the affected course enrollments 
5. For each course enrollments found in step 4, adjust the start and end dates by adding numberOfHolidayWeeks

By following this approach, not only do we account for the holiday duration, but we also maintain the original order of the courses.
However, in the real world, there may be other factors to consider. 
One issue that may occur, course enrollments adjusted with the new start and end dates may be full. Further business rule knowledge would be needed to account for this possible scenario and to further expand on the algorithm.
