using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Zad2Serializer.ObjectModel;

namespace Zad2Serializer.Serialization
{
    public class XMLSerialization<T>
    {
        public bool Validation { get; set; }

        private string _fileName;
        private T _obj;
        private JsonSerializerSettings _jsonSettings;

        public XMLSerialization(string fileName, T obj)
        {
            _fileName = fileName;
            _obj = obj;
            _jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.All
            };
        }

        public void Serialize()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }

            string json = JsonConvert.SerializeObject(_obj, Newtonsoft.Json.Formatting.Indented, _jsonSettings);
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json, "root");

            doc.Save(_fileName);

        }

        public T Deserialize()
        {
            if (!File.Exists(_fileName))
            {
                throw new FileNotFoundException();
            }

            string xml = File.ReadAllText(_fileName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);
            if (Validation) {
                validate(jsonText);
            }
            T deserializedObject = JsonConvert.DeserializeObject<T>(jsonText, _jsonSettings);
            return deserializedObject;
        }

        private void validate(string jsonText)
        {
            var schema = "";
            if (_obj is A) 
            {
                schema = aSchema;
            }
            else if (_obj is B)
            {
                schema = bSchema;
            }
            else if (_obj is C)
            {
                schema = cSchema;
            } else
            {
                throw new InvalidDataException();
            }

            JSchema sch = JSchema.Parse(schema);
            JObject schemaTest = JObject.Parse(jsonText);

            IList<string> errMess;
            if (!schemaTest.IsValid(sch, out errMess)) 
            {
                throw new InvalidDataException(errMess[0]);
            }

        }

        #region priv
        private string aSchema = @"{
    '$schema': 'http://json-schema.org/draft-07/schema',
    '$id': 'http://example.com/example.json',
    'type': 'object',
    'title': 'The root schema',
    'description': 'The root schema comprises the entire JSON document.',
    'default': {},
    'required': [
        '$id',
        '$type',
        'Name',
        'LastName',
        'Number',
        'Date',
        'ObjB'
    ],
    'properties': {
        '$id': {
            '$id': '#/properties/%24id',
            'type': 'string',
            'title': 'The $id schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                '1'
            ]
        },
        '$type': {
            '$id': '#/properties/%24type',
            'type': 'string',
            'title': 'The $type schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                'Zad2Serializer.ObjectModel.A, Zad2Serializer'
            ]
        },
        'Name': {
            '$id': '#/properties/Name',
            'type': 'string',
            'title': 'The Name schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                'Dominik'
            ]
        },
        'LastName': {
            '$id': '#/properties/LastName',
            'type': 'string',
            'title': 'The LastName schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                'Karski'
            ]
        },
        'Number': {
            '$id': '#/properties/Number',
            'type': 'string',
            'title': 'The Number schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
                3333
            ]
        },
        'Date': {
            '$id': '#/properties/Date',
            'type': 'string',
            'title': 'The Date schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                '2019-12-01T00:00:00'
            ]
        },
        'ObjB': {
            '$id': '#/properties/ObjB',
            'type': 'object',
            'title': 'The ObjB schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': {},
            'examples': [
                {
                    '$id': '2',
                    '$type': 'Zad2Serializer.ObjectModel.B, Zad2Serializer',
                    'Name': 'Sebastian',
                    'LastName': 'Kujawski',
                    'Number': 9669,
                    'Date': '2019-10-01T00:00:00',
                    'ObjC': {
                        '$id': '3',
                        '$type': 'Zad2Serializer.ObjectModel.C, Zad2Serializer',
                        'Name': 'Winston',
                        'LastName': 'Churchill',
                        'Number': 5321,
                        'Date': '2020-01-02T00:00:00',
                        'ObjA': {
                            '$ref': '1'
                        }
                    }
                }
            ],
            'required': [
                '$id',
                '$type',
                'Name',
                'LastName',
                'Number',
                'Date',
                'ObjC'
            ],
            'properties': {
                '$id': {
                    '$id': '#/properties/ObjB/properties/%24id',
                    'type': 'string',
                    'title': 'The $id schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        '2'
                    ]
                },
                '$type': {
                    '$id': '#/properties/ObjB/properties/%24type',
                    'type': 'string',
                    'title': 'The $type schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        'Zad2Serializer.ObjectModel.B, Zad2Serializer'
                    ]
                },
                'Name': {
                    '$id': '#/properties/ObjB/properties/Name',
                    'type': 'string',
                    'title': 'The Name schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        'Sebastian'
                    ]
                },
                'LastName': {
                    '$id': '#/properties/ObjB/properties/LastName',
                    'type': 'string',
                    'title': 'The LastName schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        'Kujawski'
                    ]
                },
                'Number': {
                    '$id': '#/properties/ObjB/properties/Number',
                    'type': 'string',
                    'title': 'The Number schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': 0,
                    'examples': [
                        9669
                    ]
                },
                'Date': {
                    '$id': '#/properties/ObjB/properties/Date',
                    'type': 'string',
                    'title': 'The Date schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        '2019-10-01T00:00:00'
                    ]
                },
                'ObjC': {
                    '$id': '#/properties/ObjB/properties/ObjC',
                    'type': 'object',
                    'title': 'The ObjC schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': {},
                    'examples': [
                        {
                            '$id': '3',
                            '$type': 'Zad2Serializer.ObjectModel.C, Zad2Serializer',
                            'Name': 'Winston',
                            'LastName': 'Churchill',
                            'Number': 5321,
                            'Date': '2020-01-02T00:00:00',
                            'ObjA': {
                                '$ref': '1'
                            }
                        }
                    ],
                    'required': [
                        '$id',
                        '$type',
                        'Name',
                        'LastName',
                        'Number',
                        'Date',
                        'ObjA'
                    ],
                    'properties': {
                        '$id': {
                            '$id': '#/properties/ObjB/properties/ObjC/properties/%24id',
                            'type': 'string',
                            'title': 'The $id schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                '3'
                            ]
                        },
                        '$type': {
                            '$id': '#/properties/ObjB/properties/ObjC/properties/%24type',
                            'type': 'string',
                            'title': 'The $type schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                'Zad2Serializer.ObjectModel.C, Zad2Serializer'
                            ]
                        },
                        'Name': {
                            '$id': '#/properties/ObjB/properties/ObjC/properties/Name',
                            'type': 'string',
                            'title': 'The Name schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                'Winston'
                            ]
                        },
                        'LastName': {
                            '$id': '#/properties/ObjB/properties/ObjC/properties/LastName',
                            'type': 'string',
                            'title': 'The LastName schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                'Churchill'
                            ]
                        },
                        'Number': {
                            '$id': '#/properties/ObjB/properties/ObjC/properties/Number',
                            'type': 'string',
                            'title': 'The Number schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': 0,
                            'examples': [
                                5321
                            ]
                        },
                        'Date': {
                            '$id': '#/properties/ObjB/properties/ObjC/properties/Date',
                            'type': 'string',
                            'title': 'The Date schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                '2020-01-02T00:00:00'
                            ]
                        },
                        'ObjA': {
                            '$id': '#/properties/ObjB/properties/ObjC/properties/ObjA',
                            'type': 'object',
                            'title': 'The ObjA schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': {},
                            'examples': [
                                {
                                    '$ref': '1'
                                }
                            ],
                            'required': [
                                '$ref'
                            ],
                            'properties': {
                                '$ref': {
                                    '$id': '#/properties/ObjB/properties/ObjC/properties/ObjA/properties/%24ref',
                                    'type': 'string',
                                    'title': 'The $ref schema',
                                    'description': 'An explanation about the purpose of this instance.',
                                    'default': '',
                                    'examples': [
                                        '1'
                                    ]
                                }
                            },
                            'additionalProperties': true
                        }
                    },
                    'additionalProperties': true
                }
            },
            'additionalProperties': true
        }
    },
    'additionalProperties': true
}";
        private string bSchema = @"{
    '$schema': 'http://json-schema.org/draft-07/schema',
    '$id': 'http://example.com/example.json',
    'type': 'object',
    'title': 'The root schema',
    'description': 'The root schema comprises the entire JSON document.',
    'default': {},
    'required': [
        '$id',
        '$type',
        'Name',
        'LastName',
        'Number',
        'Date',
        'ObjC'
    ],
    'properties': {
        '$id': {
            '$id': '#/properties/%24id',
            'type': 'string',
            'title': 'The $id schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                '1'
            ]
        },
        '$type': {
            '$id': '#/properties/%24type',
            'type': 'string',
            'title': 'The $type schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                'Zad2Serializer.ObjectModel.B, Zad2Serializer'
            ]
        },
        'Name': {
            '$id': '#/properties/Name',
            'type': 'string',
            'title': 'The Name schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                'Sebastian'
            ]
        },
        'LastName': {
            '$id': '#/properties/LastName',
            'type': 'string',
            'title': 'The LastName schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                'Kujawski'
            ]
        },
        'Number': {
            '$id': '#/properties/Number',
            'type': 'string',
            'title': 'The Number schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
                9669
            ]
        },
        'Date': {
            '$id': '#/properties/Date',
            'type': 'string',
            'title': 'The Date schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                '2019-10-01T00:00:00'
            ]
        },
        'ObjC': {
            '$id': '#/properties/ObjC',
            'type': 'object',
            'title': 'The ObjC schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': {},
            'examples': [
                {
                    '$id': '2',
                    '$type': 'Zad2Serializer.ObjectModel.C, Zad2Serializer',
                    'Name': 'Winston',
                    'LastName': 'Churchill',
                    'Number': 5321,
                    'Date': '2020-01-02T00:00:00',
                    'ObjA': {
                        '$id': '3',
                        '$type': 'Zad2Serializer.ObjectModel.A, Zad2Serializer',
                        'Name': 'Dominik',
                        'LastName': 'Karski',
                        'Number': 3333,
                        'Date': '2019-12-01T00:00:00',
                        'ObjB': {
                            '$ref': '1'
                        }
                    }
                }
            ],
            'required': [
                '$id',
                '$type',
                'Name',
                'LastName',
                'Number',
                'Date',
                'ObjA'
            ],
            'properties': {
                '$id': {
                    '$id': '#/properties/ObjC/properties/%24id',
                    'type': 'string',
                    'title': 'The $id schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        '2'
                    ]
                },
                '$type': {
                    '$id': '#/properties/ObjC/properties/%24type',
                    'type': 'string',
                    'title': 'The $type schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        'Zad2Serializer.ObjectModel.C, Zad2Serializer'
                    ]
                },
                'Name': {
                    '$id': '#/properties/ObjC/properties/Name',
                    'type': 'string',
                    'title': 'The Name schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        'Winston'
                    ]
                },
                'LastName': {
                    '$id': '#/properties/ObjC/properties/LastName',
                    'type': 'string',
                    'title': 'The LastName schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        'Churchill'
                    ]
                },
                'Number': {
                    '$id': '#/properties/ObjC/properties/Number',
                    'type': 'string',
                    'title': 'The Number schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': 0,
                    'examples': [
                        5321
                    ]
                },
                'Date': {
                    '$id': '#/properties/ObjC/properties/Date',
                    'type': 'string',
                    'title': 'The Date schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        '2020-01-02T00:00:00'
                    ]
                },
                'ObjA': {
                    '$id': '#/properties/ObjC/properties/ObjA',
                    'type': 'object',
                    'title': 'The ObjA schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': {},
                    'examples': [
                        {
                            '$id': '3',
                            '$type': 'Zad2Serializer.ObjectModel.A, Zad2Serializer',
                            'Name': 'Dominik',
                            'LastName': 'Karski',
                            'Number': 3333,
                            'Date': '2019-12-01T00:00:00',
                            'ObjB': {
                                '$ref': '1'
                            }
                        }
                    ],
                    'required': [
                        '$id',
                        '$type',
                        'Name',
                        'LastName',
                        'Number',
                        'Date',
                        'ObjB'
                    ],
                    'properties': {
                        '$id': {
                            '$id': '#/properties/ObjC/properties/ObjA/properties/%24id',
                            'type': 'string',
                            'title': 'The $id schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                '3'
                            ]
                        },
                        '$type': {
                            '$id': '#/properties/ObjC/properties/ObjA/properties/%24type',
                            'type': 'string',
                            'title': 'The $type schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                'Zad2Serializer.ObjectModel.A, Zad2Serializer'
                            ]
                        },
                        'Name': {
                            '$id': '#/properties/ObjC/properties/ObjA/properties/Name',
                            'type': 'string',
                            'title': 'The Name schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                'Dominik'
                            ]
                        },
                        'LastName': {
                            '$id': '#/properties/ObjC/properties/ObjA/properties/LastName',
                            'type': 'string',
                            'title': 'The LastName schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                'Karski'
                            ]
                        },
                        'Number': {
                            '$id': '#/properties/ObjC/properties/ObjA/properties/Number',
                            'type': 'string',
                            'title': 'The Number schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': 0,
                            'examples': [
                                3333
                            ]
                        },
                        'Date': {
                            '$id': '#/properties/ObjC/properties/ObjA/properties/Date',
                            'type': 'string',
                            'title': 'The Date schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                '2019-12-01T00:00:00'
                            ]
                        },
                        'ObjB': {
                            '$id': '#/properties/ObjC/properties/ObjA/properties/ObjB',
                            'type': 'object',
                            'title': 'The ObjB schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': {},
                            'examples': [
                                {
                                    '$ref': '1'
                                }
                            ],
                            'required': [
                                '$ref'
                            ],
                            'properties': {
                                '$ref': {
                                    '$id': '#/properties/ObjC/properties/ObjA/properties/ObjB/properties/%24ref',
                                    'type': 'string',
                                    'title': 'The $ref schema',
                                    'description': 'An explanation about the purpose of this instance.',
                                    'default': '',
                                    'examples': [
                                        '1'
                                    ]
                                }
                            },
                            'additionalProperties': true
                        }
                    },
                    'additionalProperties': true
                }
            },
            'additionalProperties': true
        }
    },
    'additionalProperties': true
}";
        private string cSchema = @"{
    '$schema': 'http://json-schema.org/draft-07/schema',
    '$id': 'http://example.com/example.json',
    'type': 'object',
    'title': 'The root schema',
    'description': 'The root schema comprises the entire JSON document.',
    'default': {},
    'required': [
        '$id',
        '$type',
        'Name',
        'LastName',
        'Number',
        'Date',
        'ObjA'
    ],
    'properties': {
        '$id': {
            '$id': '#/properties/%24id',
            'type': 'string',
            'title': 'The $id schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                '1'
            ]
        },
        '$type': {
            '$id': '#/properties/%24type',
            'type': 'string',
            'title': 'The $type schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                'Zad2Serializer.ObjectModel.C, Zad2Serializer'
            ]
        },
        'Name': {
            '$id': '#/properties/Name',
            'type': 'string',
            'title': 'The Name schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                'Winston'
            ]
        },
        'LastName': {
            '$id': '#/properties/LastName',
            'type': 'string',
            'title': 'The LastName schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                'Churchill'
            ]
        },
        'Number': {
            '$id': '#/properties/Number',
            'type': 'string',
            'title': 'The Number schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': 0,
            'examples': [
                5321
            ]
        },
        'Date': {
            '$id': '#/properties/Date',
            'type': 'string',
            'title': 'The Date schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': '',
            'examples': [
                '2020-01-02T00:00:00'
            ]
        },
        'ObjA': {
            '$id': '#/properties/ObjA',
            'type': 'object',
            'title': 'The ObjA schema',
            'description': 'An explanation about the purpose of this instance.',
            'default': {},
            'examples': [
                {
                    '$id': '2',
                    '$type': 'Zad2Serializer.ObjectModel.A, Zad2Serializer',
                    'Name': 'Dominik',
                    'LastName': 'Karski',
                    'Number': 3333,
                    'Date': '2019-12-01T00:00:00',
                    'ObjB': {
                        '$id': '3',
                        '$type': 'Zad2Serializer.ObjectModel.B, Zad2Serializer',
                        'Name': 'Sebastian',
                        'LastName': 'Kujawski',
                        'Number': 9669,
                        'Date': '2019-10-01T00:00:00',
                        'ObjC': {
                            '$ref': '1'
                        }
                    }
                }
            ],
            'required': [
                '$id',
                '$type',
                'Name',
                'LastName',
                'Number',
                'Date',
                'ObjB'
            ],
            'properties': {
                '$id': {
                    '$id': '#/properties/ObjA/properties/%24id',
                    'type': 'string',
                    'title': 'The $id schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        '2'
                    ]
                },
                '$type': {
                    '$id': '#/properties/ObjA/properties/%24type',
                    'type': 'string',
                    'title': 'The $type schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        'Zad2Serializer.ObjectModel.A, Zad2Serializer'
                    ]
                },
                'Name': {
                    '$id': '#/properties/ObjA/properties/Name',
                    'type': 'string',
                    'title': 'The Name schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        'Dominik'
                    ]
                },
                'LastName': {
                    '$id': '#/properties/ObjA/properties/LastName',
                    'type': 'string',
                    'title': 'The LastName schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        'Karski'
                    ]
                },
                'Number': {
                    '$id': '#/properties/ObjA/properties/Number',
                    'type': 'string',
                    'title': 'The Number schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': 0,
                    'examples': [
                        3333
                    ]
                },
                'Date': {
                    '$id': '#/properties/ObjA/properties/Date',
                    'type': 'string',
                    'title': 'The Date schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': '',
                    'examples': [
                        '2019-12-01T00:00:00'
                    ]
                },
                'ObjB': {
                    '$id': '#/properties/ObjA/properties/ObjB',
                    'type': 'object',
                    'title': 'The ObjB schema',
                    'description': 'An explanation about the purpose of this instance.',
                    'default': {},
                    'examples': [
                        {
                            '$id': '3',
                            '$type': 'Zad2Serializer.ObjectModel.B, Zad2Serializer',
                            'Name': 'Sebastian',
                            'LastName': 'Kujawski',
                            'Number': 9669,
                            'Date': '2019-10-01T00:00:00',
                            'ObjC': {
                                '$ref': '1'
                            }
                        }
                    ],
                    'required': [
                        '$id',
                        '$type',
                        'Name',
                        'LastName',
                        'Number',
                        'Date',
                        'ObjC'
                    ],
                    'properties': {
                        '$id': {
                            '$id': '#/properties/ObjA/properties/ObjB/properties/%24id',
                            'type': 'string',
                            'title': 'The $id schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                '3'
                            ]
                        },
                        '$type': {
                            '$id': '#/properties/ObjA/properties/ObjB/properties/%24type',
                            'type': 'string',
                            'title': 'The $type schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                'Zad2Serializer.ObjectModel.B, Zad2Serializer'
                            ]
                        },
                        'Name': {
                            '$id': '#/properties/ObjA/properties/ObjB/properties/Name',
                            'type': 'string',
                            'title': 'The Name schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                'Sebastian'
                            ]
                        },
                        'LastName': {
                            '$id': '#/properties/ObjA/properties/ObjB/properties/LastName',
                            'type': 'string',
                            'title': 'The LastName schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                'Kujawski'
                            ]
                        },
                        'Number': {
                            '$id': '#/properties/ObjA/properties/ObjB/properties/Number',
                            'type': 'string',
                            'title': 'The Number schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': 0,
                            'examples': [
                                9669
                            ]
                        },
                        'Date': {
                            '$id': '#/properties/ObjA/properties/ObjB/properties/Date',
                            'type': 'string',
                            'title': 'The Date schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': '',
                            'examples': [
                                '2019-10-01T00:00:00'
                            ]
                        },
                        'ObjC': {
                            '$id': '#/properties/ObjA/properties/ObjB/properties/ObjC',
                            'type': 'object',
                            'title': 'The ObjC schema',
                            'description': 'An explanation about the purpose of this instance.',
                            'default': {},
                            'examples': [
                                {
                                    '$ref': '1'
                                }
                            ],
                            'required': [
                                '$ref'
                            ],
                            'properties': {
                                '$ref': {
                                    '$id': '#/properties/ObjA/properties/ObjB/properties/ObjC/properties/%24ref',
                                    'type': 'string',
                                    'title': 'The $ref schema',
                                    'description': 'An explanation about the purpose of this instance.',
                                    'default': '',
                                    'examples': [
                                        '1'
                                    ]
                                }
                            },
                            'additionalProperties': true
                        }
                    },
                    'additionalProperties': true
                }
            },
            'additionalProperties': true
        }
    },
    'additionalProperties': true
}";
        #endregion
    }
}
