dbdocs connects to SQL Server and produce documentation for Tables, Function, Stored Procedures, Views, User Defined Data Types (plus, columns, parameters and return values) within each database defined in the config.json file.
The output is a json file presented in HTML document with JavaScript parsing models.

Start
Get and Validate config from JSON file (default: app location, if not found ask user for file path)
Validate user access for each database specified in config file (check if user is dbo)
    - capture exceptions if any
    - allow user to continue or terminate
Process each database
    - get list of all objects in the db (for documentation links)
      - generate UID for each object (database_id.schema_id.object_id.column_id)
    - get tables
      - get columns
    - get views
      - get columns
    - get stored procedures
      - get parameters
    - get functions
      - get parameters
    - get user data types
Serialize server object to JSON
Save to output location (in config file, if null - use default, copy html and js script)
Open HTML file
End