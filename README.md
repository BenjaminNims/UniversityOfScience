# University of Science

An ongoing .NET/EF6 web project that implements user authorizations to restrict or allow access to features and data.

At completion, a user will be able to log in as a student, professor, department head, or administrator, and will have differing read/write permissions and access to certain data and website pages.

# Playthrough URL

https://www.youtube.com/watch?v=UeY5Ido5l7w

## Technologies Used

.NET Core/EF 6 with Razor Pages, Postgres/pgadmin, Identity

## Note on Deployment

Application is not yet deployed due to bugs/unsupported features in Visual Studio for Mac's deployment and database management engines. Configuration is currently taking place between VS for Mac, AWS Elastic Beanstalk/RDS, and pgadmin4. Deployment to Azure from this repository was successful, but at present there is a 403 Forbidden error at the endpoint that I have not been able to debug. Link is listed below for reference, but the project's functionality is still accessible through the YouTube link above.

https://universityofscience.azurewebsites.net
