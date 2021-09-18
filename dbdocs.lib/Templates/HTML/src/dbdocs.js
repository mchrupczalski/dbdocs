function displayObject() {
    document.getElementById('display').innerHTML = docsData.Databases[0].Name;
}






const docsData = {
    "Databases": [
        {
            "Uid": "18",
            "Name": "db1",
            "CreateDate": "2021-09-18T20:36:24.383Z",
            "CompatibilityLevel": 150,
            "Collation": "Latin1_General_CI_AS",
            "UserAccess": "MULTI_USER",
            "IsReadOnly": false,
            "Tables": [
                {
                    "Uid": "18.581577110",
                    "Name": "Table_1",
                    "ObjectId": 581577110,
                    "SchemaName": "dbo",
                    "DateCreated": "2021-09-18T20:37:18.697Z",
                    "DateModified": "2021-09-18T20:37:18.707Z",
                    "TblExtendedDesc": null,
                    "Fields": [
                        {
                            "ColumnId": 1,
                            "ColumnName": "ID",
                            "DataType": "int",
                            "MaxLen": 4,
                            "Precision": 10,
                            "Scale": 0,
                            "IsNullable": false,
                            "IsIdentity": false,
                            "IsComputed": false,
                            "DefaultVal": null,
                            "ColExtendedDesc": null,
                            "IsPK": true,
                            "IsFK": false
                        },
                        {
                            "ColumnId": 2,
                            "ColumnName": "Name",
                            "DataType": "nchar",
                            "MaxLen": 20,
                            "Precision": 0,
                            "Scale": 0,
                            "IsNullable": true,
                            "IsIdentity": false,
                            "IsComputed": false,
                            "DefaultVal": null,
                            "ColExtendedDesc": null,
                            "IsPK": false,
                            "IsFK": false
                        }
                    ]
                },
                {
                    "Uid": "18.613577224",
                    "Name": "Table_2",
                    "ObjectId": 613577224,
                    "SchemaName": "dbo",
                    "DateCreated": "2021-09-18T20:37:40.127Z",
                    "DateModified": "2021-09-18T20:37:40.137Z",
                    "TblExtendedDesc": null,
                    "Fields": [
                        {
                            "ColumnId": 1,
                            "ColumnName": "ID",
                            "DataType": "int",
                            "MaxLen": 4,
                            "Precision": 10,
                            "Scale": 0,
                            "IsNullable": false,
                            "IsIdentity": false,
                            "IsComputed": false,
                            "DefaultVal": null,
                            "ColExtendedDesc": null,
                            "IsPK": true,
                            "IsFK": false
                        },
                        {
                            "ColumnId": 2,
                            "ColumnName": "Age",
                            "DataType": "int",
                            "MaxLen": 4,
                            "Precision": 10,
                            "Scale": 0,
                            "IsNullable": true,
                            "IsIdentity": false,
                            "IsComputed": false,
                            "DefaultVal": null,
                            "ColExtendedDesc": null,
                            "IsPK": false,
                            "IsFK": false
                        },
                        {
                            "ColumnId": 3,
                            "ColumnName": "Address",
                            "DataType": "nchar",
                            "MaxLen": 20,
                            "Precision": 0,
                            "Scale": 0,
                            "IsNullable": true,
                            "IsIdentity": false,
                            "IsComputed": false,
                            "DefaultVal": null,
                            "ColExtendedDesc": null,
                            "IsPK": false,
                            "IsFK": false
                        }
                    ]
                }
            ]
        },
        {
            "Uid": "19",
            "Name": "db2",
            "CreateDate": "2021-09-18T20:37:56.117Z",
            "CompatibilityLevel": 150,
            "Collation": "Latin1_General_CI_AS",
            "UserAccess": "MULTI_USER",
            "IsReadOnly": false,
            "Tables": [
                {
                    "Uid": "19.581577110",
                    "Name": "Table_1",
                    "ObjectId": 581577110,
                    "SchemaName": "dbo",
                    "DateCreated": "2021-09-18T20:38:45.487Z",
                    "DateModified": "2021-09-18T20:38:45.497Z",
                    "TblExtendedDesc": null,
                    "Fields": [
                        {
                            "ColumnId": 1,
                            "ColumnName": "Id",
                            "DataType": "int",
                            "MaxLen": 4,
                            "Precision": 10,
                            "Scale": 0,
                            "IsNullable": false,
                            "IsIdentity": false,
                            "IsComputed": false,
                            "DefaultVal": null,
                            "ColExtendedDesc": null,
                            "IsPK": true,
                            "IsFK": false
                        },
                        {
                            "ColumnId": 2,
                            "ColumnName": "Color",
                            "DataType": "nchar",
                            "MaxLen": 20,
                            "Precision": 0,
                            "Scale": 0,
                            "IsNullable": true,
                            "IsIdentity": false,
                            "IsComputed": false,
                            "DefaultVal": null,
                            "ColExtendedDesc": null,
                            "IsPK": false,
                            "IsFK": false
                        }
                    ]
                },
                {
                    "Uid": "19.613577224",
                    "Name": "Table_2B",
                    "ObjectId": 613577224,
                    "SchemaName": "dbo",
                    "DateCreated": "2021-09-18T20:39:14.13Z",
                    "DateModified": "2021-09-18T20:39:14.14Z",
                    "TblExtendedDesc": null,
                    "Fields": [
                        {
                            "ColumnId": 1,
                            "ColumnName": "ID",
                            "DataType": "nchar",
                            "MaxLen": 20,
                            "Precision": 0,
                            "Scale": 0,
                            "IsNullable": false,
                            "IsIdentity": false,
                            "IsComputed": false,
                            "DefaultVal": null,
                            "ColExtendedDesc": null,
                            "IsPK": true,
                            "IsFK": false
                        },
                        {
                            "ColumnId": 2,
                            "ColumnName": "Band",
                            "DataType": "nchar",
                            "MaxLen": 20,
                            "Precision": 0,
                            "Scale": 0,
                            "IsNullable": true,
                            "IsIdentity": false,
                            "IsComputed": false,
                            "DefaultVal": null,
                            "ColExtendedDesc": null,
                            "IsPK": false,
                            "IsFK": false
                        }
                    ]
                }
            ]
        }
    ]
}