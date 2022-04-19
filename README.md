<h2>.Net core onion architecture boilerplate</h2>

<h4># Rent2Go is mobile number authentication based .net core prject where onion architecture has been used.You can start your api integration from the first day witout spending time on creating skeleton of the project.</h4>

![onion_architecture](https://user-images.githubusercontent.com/10800787/163911867-59d311b7-e53e-49c4-9ccf-442060e950a2.jpeg)


<h2>How to use and check features</h2>
<li>You will need Visual Studio 2022 for supporting .Net 6.</li>
<li>You will need a MSSQL database.</li>
<li><b>Sql server 2019</b> has been used for this project</li>
<li>After opening the project configure your database connection string </li>
<li>Opten <b>Package manager console</b> the type <b>update-database</b></li>
<li>It will create your database according to connection string.</li>
<li>Go to "DatabaseManagement/Initialize" folder from application source folder</li>
<li>Run all script sequentially (it will input UserRole and UserStatus values in db)</li>
<li>Run the application</li>
<li>To create user first call "SendOtp" api. Default verification code is 1234 that will saved in db</li>
<li>Then call "api/User/Authentication/" where Mbobile Number and Code field is mandatory</li>
<li>If user eith the mobile number already exist it will just retrun success messge otherwise new user will be created with role "User"</li>
<li>To test Authorization call "Test" api.

<h2>Technologies implemented:</h2>
<li>.Nett 6</li>
<li>Entityframework core 6(Code first)</li>
<li>.Net core Identity for authentication and authorization</li>
<li>Customise Identity model</li>
<li>Automapper</li>
<li>Fluent api for both model validation and DBModel configuration</li>
<li>Used Generic Repository Pattern for DB operation</li>
<li>Implemented Swagger</li>
<li>Dependency Injection</li>
<li>Followed Seperation Of Concern mechanism</li>
<li>Used Custom MIddleware</li>
<li>Global Error Handling</li>
<li>Serilog for application logging in DB</li>
