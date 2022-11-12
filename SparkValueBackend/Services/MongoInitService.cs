﻿using MongoDB.Bson;
using MongoDB.Driver;
using SparkValueBackend.Models;
using SparkValueBackend.Services.UnitCreators;
using SparkValueBackend.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoUtils = SparkValueBackend.Services.Utils.MongoUtils;

namespace SparkValueBackend.Services
{
    public class MongoInitService : MongoUtils
    {
        private IUnitCreator _unitCreator;

        private readonly string _unitCollection;

        List<UnitModel> _defaultUnits = new List<UnitModel>()
        {
            new UnitModel("Shocking Introduction",
                1,
                "Basic concepts to explore.",
                new List<LessonModel>
                {
                    new LessonModel("Electricity Primer",
                        1,
                        "An intro to electricity.", new List<string>
                        {
                            "We all ask what electricity is because to most it is this powerful, invisible force that keeps our lives moving. However, it is not all as mysterious as some declare it to be. This power comes from atoms and the flow of electrons between them. I will not be getting all sciency here about the reasons why they move. Just keep in mind that electrons move in a path from a negative to a positive source. But what do electrons move through? How do electrons follow a certain path? The answer to both questions is simply yes. Electrons move through everything and anything, it is just a matter of how conductive the material or thing is. The more conductive the material is, the easier it is for electrons to flow through it. The less conductive the material is, the harder it is for electrons to flow through it. These are called conductors and insulators, respectively. Think of a wire, the copper core is a conductor that lets electrons flow easily and the hard plastic or rubber casing prevents those electrons from escaping the conductor.",
                            "With that basic knowledge of electrons, conductors, and insulators, let us move into more exciting terms to understand our circuit better. Some of the most common things you will hear are Voltage, Current, and Resistance. Voltage is the difference in charge between two points. Current is the rate at which the charge flows. And Resistance is a material’s tendency to resist or impede the flow of charge. How do these new terms relate? Well, it all boils down to a fundamental law that describes these relationships and their effect in a circuit. This is Ohm’s Law. The mathematical formula is as follows: Voltage divided by the product of the Current and Resistance. Voltage is represented by a V or E in older diagrams and is measured in Volts. Current is represented by an I and measured in Amps. And Resistance is represented by an R and measured in Ohms. See the below diagram and examples for a more visual interpretation of Ohm’s Law.",
                            "One last thing, I earlier said that electrons flow from a negative to a positive source. But isn’t that wrong? Actually no. Many people learn that electricity flows from a positive to a negative source. I hope you are sitting down for this, but this is wrong or at least partially wrong. What we have been taught is known as Conventional Flow, which is the working, standard practice to use in most places. However, Electron Flow is the real deal. Although Electron Flow is more accurate, this application will show everything in Conventional Flow for ease of use. There are more examples of Ohm’s Law on the right and just as a teaser, next lesson we will dive into circuits!"
                        },
                        new List<string>
                        {
                            "",
                            "OhmsLawCollective",
                            "OhmsLawAdvanced"
                        },
                        new List<int>
                        {
                            0,
                            3,
                            1
                        }),
                    new LessonModel("Reading Circuit Diagrams",
                        2,
                        "Learn how to read circuit diagrams so you can build your own.", new List<string>
                        {
                            "Circuit diagrams can be complex, so let’s demystify them. First things first, let’s define some vocabulary. First up, a circuit can have one or more load devices. A load device is an object, like a light bulb or motor, that uses the current flowing through the circuit. Speaking of flowing through a circuit, one of the most important things is wires. On diagrams, if a wire ends in a circle or node that means it is connected to another wire or other components. Nodes are considered junctions between items. If a wire goes under another wire without a node present that means they are not connected. These paths are also important. A node can connect to a singular item or multiple. When it connects to a singular item that item is in series and if it connects to multiple items those items are in parallel. Series and parallel circuits are shown in more detail above. Also, be careful when reconstructing circuits from diagrams. Make sure there is always a path from your positive terminal to the negative terminal and there is some kind of load in that path. Next up we will be talking about some of the archaic, alien symbols found in circuit diagrams.",
                            "Now I will not be discussing every symbol and every variation of these symbols, but I will show off the popular symbols that you will see most commonly. In addition, if you are looking for more details on these components keep reading, you will learn more about them in due time. As you can see to the left there is a vast amount of these symbols. The most common symbols are resistors, diodes, transistors, and capacitors. There are also symbols for your power supply or battery and switches. Some other symbols pictured here include inductors, logic gates, and microcontrollers. This barely scratches the surface of what you will see, but this gives you a general idea of what to expect on circuit diagrams. Next time, we will start diving deeper into the world of components."
                        },
                        new List<string>
                        {
                            "LoadsAndNodes",
                            "ExampleDiagrams"
                        },
                        new List<int>
                        {
                            4,
                            2
                        }),
                    new LessonModel("Discussion of Components",
                        3,
                        "A brief introduction to the vast world of components.", new List<string>
                        {
                            "Electronics have evolved over the years, at first, all our components were large and bulky. Now they are as small as grains of rice or even smaller. However, for beginner electronics, we will not dwell in the realm of Surface Mounted Devices, or SMD for short. SMD components are smaller and more efficient in the manufacturing process. However, they are harder to learn from and use as a beginner. This is why we will be focusing on THT or Through Hole Technology. THT components are considerably harder to work with in manufacturing since holes need to be drilled through circuit boards, but are excellent for beginners and rapid prototyping. Through the next two units, you will learn more about specific components and their usage. If you are still curious about our evolution in circuit design, crack open older electronics and compare them to current devices. Happy exploring! Now, it is time to go down the rabbit hole of components."
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        })
                }),
            new UnitModel("Components Galore",
                2,
                "Basic components and what they do.",
                new List<LessonModel>
                {
                    new LessonModel("Resistors",
                        1,
                        "Resist that power, bring it down.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Diodes",
                        2,
                        "Manage the flow of electricity.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Light Emitting Diodes",
                        3,
                        "An indication of a lively circuit.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Capacitors",
                        4,
                        "Storing electricity like a champ.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Transistors",
                        5,
                        "An electrical checkpoint.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Inductors",
                        6,
                        "Magnetic fields of stored electricity.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        })
                }),
            new UnitModel("Miscellaneous Components",
                3,
                "Even more components and what they do.",
                new List<LessonModel>
                {
                    new LessonModel("Logic Gates",
                        1,
                        "Logic at its finest.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Integrated Circuits",
                        2,
                        "Tiny circuits within circuits.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Switches",
                        3,
                        "Pull the lever.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Buttons",
                        4,
                        "Be careful what you press.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        })
                }),
            new UnitModel("Putting it Down",
                4,
                "A neat place for every little thing.",
                new List<LessonModel>
                {
                    new LessonModel("Breadboards",
                        1,
                        "A board for bread and wires.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Printed Circuit Boards",
                        2,
                        "A green board with all those funky holes.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Microcontrollers and Beyond",
                        3,
                        "Pre-made circuits with even more possibilities.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        })
                }),
            new UnitModel("Common Tools",
                5,
                "Tools of the trade.",
                new List<LessonModel>
                {
                    new LessonModel("Multimeter",
                        1,
                        "A way to monitor your ins and outs.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Oscilloscope",
                        2,
                        "Watching the waves of electricity.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Power Supply",
                        3,
                        "Unlimited POWER!", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Soldering Iron",
                        4,
                        "Fusing metal together, making bonds that last.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        }),
                    new LessonModel("Start Making",
                        5,
                        "Show the world your new found skills.", new List<string>
                        {
                            ""
                        },
                        new List<string>
                        {
                            ""
                        },
                        new List<int>
                        {
                            0
                        })
                })
        };

        public MongoInitService(string connectionString, string databaseName, string unitCollection) : base(connectionString, databaseName)
        {
            _unitCollection = unitCollection;
            _unitCreator = new MongoUnitCreator(connectionString, databaseName, _unitCollection);

            InitializeUnits();
        }

        private async void InitializeUnits()
        {
            IMongoCollection<UnitModel> unitCollection = ConnectToMongo<UnitModel>(_unitCollection);
            if (unitCollection.CountDocuments(new BsonDocument()) > 0) return;

            // If there are no documents in the units collection add the default units
            foreach (UnitModel unit in _defaultUnits)
            {
                await _unitCreator.CreateUnit(unit);
            }
        }
    }
}
