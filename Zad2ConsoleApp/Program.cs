using System;
using System.IO;
using Zad2Serializer.ObjectModel;
using Zad2Serializer.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Zad2ConsoleApp
{
    class Program
    {
        static ABC changeType(A a, B b, C c)
        {

          

            Console.WriteLine("Choose type A / B / C" + "\n");
            char x = Convert.ToChar(Console.ReadLine());
            switch (x)
            {
                case 'A':
                    {
                        return a;
                    }
                case 'B':
                    {
                        return b;
                    }
                case 'C':
                    {
                        return c;
                    }
                case 'a':
                    {
                        return a;
                    }
                case 'b':
                    {
                        return b;
                    }
                case 'c':
                    {
                        return c;
                    }
                default:
                    {
                        return a;
                    }
            }

        }


        static void Main(string[] args)
        {

            int y = 10;



            A a;
            B b;
            C c;

            a = new A("Dominik", "Karski", 3333, new DateTime(2019, 12, 1), null);
            b = new B("Sebastian", "Kujawski", 9669, new DateTime(2019, 10, 1), null);
            c = new C("Winston", "Churchill", 5321, new DateTime(2020, 1, 2), null);

            a.ObjB = b;
            b.ObjC = c;
            c.ObjA = a;
            int x = -1;
            ABC holder = a;


            while (x != 0)
            {
                Console.Clear();
                Console.WriteLine("JSON serialization (1)");
                Console.WriteLine("JSON deserialization (2)");
                Console.WriteLine("Custom serialization (3)");
                Console.WriteLine("Custom deserialization (4)");
                Console.WriteLine("Change type from " + holder.GetType().Name +" (5)");
                Console.WriteLine("XML serialization (6)");
                Console.WriteLine("XML deserialization (7)");
                Console.WriteLine("XML to XHTML transformation (8)");
                Console.WriteLine("Quit (0)");
                x = Convert.ToInt32(Console.ReadLine());
                switch(x){
                    case 1:
                        {
                            JSONSerialization<ABC> serialize = new JSONSerialization<ABC>("AConsoleResultJSON.json", holder);
                            serialize.Serialize();
                            Console.WriteLine("Object " + holder.GetType().Name + " serialized to JSON format" + "\n");
                            break;
                        }                
                    case 2:
                        {
                            #region jsonschema
                            string schemastr = "";
                            if (holder is A)
                            {
                                schemastr = @"{
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
            'type': 'integer',
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
                    'type': 'integer',
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
                            'type': 'integer',
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
                            } else if (holder is B)
                            {
                                schemastr = @"{
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
            'type': 'number',
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
                    'type': 'number',
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
                            'type': 'number',
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
                            } else if (holder is C)
                            {
                                schemastr = @"{
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
            'type': 'number',
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
                    'type': 'number',
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
                            'type': 'number',
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
                            }
                            #endregion

                            JSchema schema = JSchema.Parse(schemastr);

                            string fileName = "AConsoleJsonDesTmp.json";
                            JSONSerialization<ABC> serialize = new JSONSerialization<ABC>(fileName, holder);
                            serialize.Serialize();
                            string jsonText = File.ReadAllText(fileName);
                            JObject schemaTest = JObject.Parse(jsonText);

                            IList<string> errorMessages;
                            bool valid = schemaTest.IsValid(schema, out errorMessages); 

                            if (valid)
                            {
                                ABC desResult = serialize.Deserialize();
                                Console.WriteLine("Object " + holder.GetType().Name + " deserialized from JSON format" + "\n");
                                Console.WriteLine(desResult.ToString());
                                break;
                            }
                            foreach (var e in errorMessages)
                            {
                                Console.WriteLine(e);
                            }
                            
                            Console.WriteLine("Validation Error");
                            break;
                        }
                    case 3:
                        {
                            CustomSerialization<ABC> serialize = new CustomSerialization<ABC>("AConsoleSerializationResultCustom.txt", holder);
                            serialize.Serialize();
                            Console.WriteLine("Object " + holder.GetType().Name + "serialized to custom format" + "\n");
                            break;
                        }
                    case 4:
                        {
                            string fileName = "AConsoleCustomDesTmp.txt";
                            CustomSerialization<ABC> serialize = new CustomSerialization<ABC>(fileName, holder);
                            serialize.Serialize();
                            CustomSerialization<ABC> tmp = new CustomSerialization<ABC>(fileName, holder);
                            ABC desResult = tmp.Deserialize();
                            Console.WriteLine("Object " + holder.GetType().Name +" deserialized from Custom format" + "\n");
                            Console.WriteLine(desResult.ToString());

                            break;
                        }
                    case 5:
                        {
                            holder = changeType(a, b, c);
                            Console.WriteLine("Object type changed to " + holder.GetType().Name);
                            break;
                        }
                    case 6:
                        {
                            XMLSerialization<ABC> serialize = new XMLSerialization<ABC>("AConsoleResultXML.xml", holder);
                            serialize.Serialize();
                            Console.WriteLine("Object " + holder.GetType().Name + " serialized to XML format" + "\n");
                            break;
                        }
                    case 7:
                        {
                            string fileName = "AConsoleResultXML.xml";
                            XMLSerialization<ABC> serialize = new XMLSerialization<ABC>(fileName, holder);
                            serialize.Serialize();
                            XMLSerialization<ABC> tmp = new XMLSerialization<ABC>(fileName, holder);
                            ABC desResult = tmp.Deserialize();
                            Console.WriteLine("Object " + holder.GetType().Name + " deserialized from XML format" + "\n");
                            Console.WriteLine(desResult.ToString());
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Level of recursion: ");
                            y = Convert.ToInt32(Console.ReadLine());
                            string fileName = "AConsoleResultXML.xml";
                            if (!File.Exists(fileName))
                            {
                                Console.WriteLine("Nie odnaleziono pliku xml.");
                                break;
                            }

                            XPathDocument myXPathDoc = new XPathDocument(fileName);

                            
                            string xsltCode = "<?xml version='1.0' encoding='UTF-8'?><xsl:stylesheet version ='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform' xmlns:json='http://james.newtonking.com/projects/json'><xsl:output method = 'xml' doctype-system='http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd' doctype-public='-//W3C//DTD XHTML 1.0 Transitional//EN' indent='yes' omit-xml-declaration='yes'/><xsl:template name = 'writeobj' ><xsl:param name = 'obj' select='root'/>	<xsl:param name = 'count' select='1'/><xsl:choose><xsl:when test = '$obj/@json:ref' ><xsl:call-template name = 'writeobj' > <xsl:with-param name = 'obj' select='root'/><xsl:with-param name = 'count' select='$count'/></xsl:call-template></xsl:when><xsl:otherwise><xsl:if test='$count > 0'><tr xmlns = 'http://www.w3.org/1999/xhtml' xml:lang='pl' lang='pl' >Type: <xsl:value-of select = '$obj/@json:type' />Name: <xsl:value-of select = '$obj/Name' />LastName: <xsl:value-of select = '$obj/LastName' />Number: <xsl:value-of select = '$obj/Number' />Date: <xsl:value-of select = '$obj/Date'/><xsl:if test='$count > 1'>ObjRef: </xsl:if></tr> <xsl:if test='$obj/ObjA'><xsl:call-template name = 'writeobj' ><xsl:with-param name = 'obj' select='$obj/ObjA'/><xsl:with-param name = 'count' select='$count - 1'/></xsl:call-template></xsl:if><xsl:if test='$obj/ObjB'><xsl:call-template name = 'writeobj' ><xsl:with-param name = 'obj' select='$obj/ObjB'/><xsl:with-param name = 'count' select='$count - 1'/></xsl:call-template></xsl:if><xsl:if test='$obj/ObjC'><xsl:call-template name = 'writeobj' ><xsl:with-param name = 'obj' select='$obj/ObjC'/><xsl:with-param name ='count' select='$count - 1'/></xsl:call-template> </xsl:if></xsl:if></xsl:otherwise></xsl:choose></xsl:template> <xsl:template match = '/' ><html xmlns='http://www.w3.org/1999/xhtml' xml:lang='pl' lang='pl'><head> <title>Wynik serializacji</title> <style type = 'text/css' >mh2{,font - family: Helvetica;,margin - left: 2 %;,}   </style> </head>  <body style = 'background-color:#2c2f33; color:#7289da' ><table style='background-color:#222222'  xmlns='http://www.w3.org/1999/xhtml' xml:lang='pl' lang='pl' ><xsl:call-template name = 'writeobj' ><xsl:with-param name = 'obj' select='root'/><xsl:with-param name = 'count' select='"+y+"'/></xsl:call-template></table> </body> </html></xsl:template>	</xsl:stylesheet>";

                            XslCompiledTransform objXslTrans = new XslCompiledTransform();
                            objXslTrans.Load(new XmlTextReader(new StringReader(xsltCode)));

                            string xsltFilePath = "toxhtml.xslt";
                            if (!File.Exists(xsltFilePath))
                            {
                                Console.WriteLine("Nie odnaleziono pliku xslt.");
                                break;
                            }

                            XmlTextWriter myWriter = new XmlTextWriter("result.xhtml", null);
                            objXslTrans.Transform(myXPathDoc, null, myWriter);
              

                            Console.WriteLine("Stworzono plik result.xhtml");
                            break;
                        }
                }
                Console.WriteLine("\n" + "Press Key to Continue");
                Console.ReadKey();

            }
            
    }
    }

}