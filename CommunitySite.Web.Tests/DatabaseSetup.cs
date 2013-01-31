using System;
using System.Collections.Generic;
using System.Linq;
using CommunitySite.Web.Data.Models;
using NUnit.Framework;
using XmlRepository.DataProviders;

namespace CommunitySite.Tests
{
    [TestFixture]
    class DatabaseSetup
    {
        private List<Person> _persons;
        private List<Speaker> _speakers;
        private List<Location> _locations;
        private List<Event> _events;


        [SetUp]
        public void Setup()
        {
            XmlRepository.XmlRepository.DefaultQueryProperty = "Id";
            XmlRepository.XmlRepository.DataProvider = new XmlFileProvider(@"C:\Git\UsergroupWebsite\CommunitySite.Web\App_Data");
        }

        [Test]
        public void DbSetup()
        {
            CreatePersonRepo();
            CreateSpeakerRepo();
            CreateLokationRepo();
            CreateEventRepo();
        }

        private void CreatePersonRepo()
        {
            _persons = new List<Person>
                {
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = ".NET-Stammtisch",
                            Lastname = "Konstanz-Kreuzlingen",
                            Email = "juergen@gutsch-online.de",
                            ImageUrl = "",
                            UseGravatar = false
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Jürgen",
                            Lastname = "Gutsch",
                            Email = "juergen@gutsch-online.de",
                            ImageUrl = "",
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Thorsten",
                            Lastname = "Hans",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = false
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Golo",
                            Lastname = "Roden",
                            Email = "webmaster@goloroden.de",
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Roberto",
                            Lastname = "Danti",
                            Email = "rdanti@outlook.com",
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Gregor",
                            Lastname = "Biswanger",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Daniel",
                            Lastname = "Marbach",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Urs",
                            Lastname = "Enzler",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Ralf",
                            Lastname = "Westphal",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Ilker",
                            Lastname = "Cetinkaya",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Thomas",
                            Lastname = "Schissler",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Thomas Claudius",
                            Lastname = "Huber",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "David",
                            Lastname = "Tielke",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Peter",
                            Lastname = "Bucher",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Constantin",
                            Lastname = "Klein",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                    new Person
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "André",
                            Lastname = "Lämmer",
                            Email = String.Empty,
                            ImageUrl = String.Empty,
                            UseGravatar = true
                        },
                };

            using (var repository = XmlRepository.XmlRepository.GetInstance<Person>())
            {
                repository.DeleteAllOnSubmit();
                repository.SubmitChanges();

                foreach (var person in _persons)
                {
                    repository.SaveOnSubmit(person);
                }
                repository.SubmitChanges();
            }
        }

        public void CreateSpeakerRepo()
        {
            _speakers = new List<Speaker>
                {
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName(".NET-Stammtisch"),
                            Description = String.Empty,
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("André"),
                            Description = String.Empty,
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Peter"),
                            Description = String.Empty,
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("David"),
                            Description =
                                @"<strong>David Tielke</strong> ist Softwareentwickler bei der Firma uniserve GmbH und entwickelt dort Videomanagementlösungen im Logistikbereich auf Basis von .NET und dem SQL Server. Seit 2008 ist er außerdem ein Microsoft Student Partner und vermittelt in Workshops sein Wissen über Microsoftprodukte an Studierende der Hochschulen in ganz Deutschland oder bei Veranstaltungen wie zum Beispiel den dotnetpro powerdays. Darüber hinaus ist er Microsoft Certified Professional (MCP) für die Entwicklung mit dem .NET-Framework und hat sich während seines Studiums an der Philipps-Universität in Marburg im Bereich Softwaretechnik und Computer Vision spezialisiert.",
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Thomas Claudius"),
                            Description =
                                @"<strong>Thomas Claudius Huber</strong> ist Senior Consultant bei der Trivadis AG in Basel. Als Trainer, Berater und Entwickler ist er in den Bereichen .NET, Java und PL/SQL tätig. Da ihn Benutzeroberflächen schon seit seinem Informatik-Studium begeisterten, spezialisierte er sich in den vergangenen Jahren auf die UI-Programmierung mit WPF und Silverlight. Er ist Autor des umfassenden Handbuchs zur Windows Presentation Foundation und des umfassenden Handbuchs zu Silverlight. Seine persönliche Seite finden Sie unter http://www.thomasclaudiushuber.com",
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Thomas"),
                            Description =
                                @"<strong>Thomas Schissler</strong> arbeitet als Projektleiter, Software-Architekt und Coach bei der artiso AG nahe Ulm und beschäftigt sich seit 2001 mit der Software-Entwicklung auf Basis von .NET. Er ist MVP für Team System und Group-Leiter der .net Dveloper-Group Ulm (www.dotnet-ulm.de) und der internationalen Visual Studio ALM User Group (www.vsalmug.com). Er hat sich auf die Themen Team Foundation Server, Moderne Architekturkonzepte, Prozessdesign und Qualitätsmanagement spezialisiert. In diversen Vorträgen gibt er praxisorientierte Tipps an Entscheider und Entwickler weiter. Er bloggt so oft wie möglich unter www.artiso.com/problog.",
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Ilker"),
                            Description =
                                @"<strong>Ilker Cetinkaya</strong>, Berater, Architekt und Entwickler bei Avanade Deutschland GmbH, entwickelt Software mit dem Microsoft .NET Framework seit der Version 1.0. Durch sein langjähriges Wirken bei großen Projekten prägt ihn ein breites & tiefes Know-How, besonders in den Themen Skalierung, Performance und Flexibilität von .NET Anwendungen; sowohl im Web- als auch im Enterprise-Umfeld. Als ausgewiesener Experte für professionelle Software-Entwicklung beschäftigt er sich seit mehreren Jahren intensiv mit den Themen agile Methoden, TDD / BDD, C# 3.0 / 4.0 und Software-Design.",
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Ralf"),
                            Description =
                                @"<strong>Ralf Westphal</strong> (www.ralfw.de) ist freiberuflicher Berater, Projektbegleiter und Trainer für Themen rund um .NET Softwarearchitektur. Er ist Autor von mehr als 450 Publikationen und Microsoft Most Valued Professional. Mit Stefan Lieser hat er die Initiative „Clean Code Developer“ für mehr Softwarequalität ins Leben gerufen (www.clean-code-developer.de).",
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Urs"),
                            Description =
                                @"<strong>Urs Enzler</strong> hat an der ETH Zürich Informatik studiert. Neben seiner Haupttätigkeit als Softwarearchitekt bei bbv Software Services AG (www.bbv.ch) unterstützt er Unternehmen bei der Einführung agiler Entwicklungsmethoden wie Scrum oder Test-driven Development. Er referiert auf Konferenzen und Tagungen in der Schweiz und in Deutschland über agile Softwareentwicklung und -architektur. Er bloggt auf http://www.planetgeek.ch.",
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Daniel"),
                            Description =
                                @"<strong>Daniel Marbach</strong> ist ein enthusiastischer Senior Software Engineer bei bbv Software Services AG in Luzern. Seine Erfahrung reicht über Mobile Applikationsentwicklung bis zu Client und Server Entwicklung mit einer starken Tendenz zu Verteilten Systemen. Daniel hat ein Abschluss als Dipl. Inf. Ing. FH von der Fachhochschule für Technik und Architektur in Horw. 

Daniel hat Stärken in Agilen Entwicklungsmethodiken wie Continuous Integration und Test Driven Development. Er ist ein regelmässiger Sprecher, Coach und passionierter Blogschreiber auf http://www.planetgeek.ch. Er ist der Co-Gründer der .NET Usergroup Zentralschweiz und auf einer immerwährenden Reise als Software Entwickler mit Überzeugung und Engagement.",
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Jürgen"),
                            Description =
                                @"<strong>Jürgen Gutsch</strong> ist Geschäftsführer, Softwareentwickler, Trainer und Berater bei der GUTSCH-ONLINE Software GmbH. Neben Familie und Beruf ist Jürgen Leiter des <strong>.NET-Stammtisch Konstanz-Kreuzlingen</strong> und betreibt ein Blog auf ASP.NET Zone zum Thema <strong>ASP.NET und mehr...</strong> Sie erreichen ihn über seinen Blog oder über juergen.gutsch@dotnetkk.de.",
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Thorsten"),
                            Description =
                                @"<strong>Thorsten Hans</strong> arbeitet als Teamlead .NET Development bei der Firma Data One in Saarbrücken. Er ist mehrfach als MCTS und MCPD zertifiziert und beschäftigt sich neben SharePoint und .NET Enterprise Entwicklung mit IronRuby, MSBuild und WF4. 
Sie erreichen Ihn über einen seiner Blogs http://www.ironruby-rocks.com, http://www.dotnet-rocks.de oder via Email unter thorsten.hans@gmail.com."
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Golo"),
                            Description =
                                @"<strong>Golo Roden</strong> ist freiberuflicher Wissensvermittler und Technologieberater für .NET, Codequalität und agile Methoden. Zu diesen Themen berät er Firmen bei der Evaluierung, Erforschung und Verwendung geeigneter Technologien und Methoden. Darüber hinaus ist er journalistisch für Fachzeitschriften und als Referent und Content Manager für Konferenzen tätig. Für sein qualitativ hochwertiges Engagement in der Community wurde Golo von Microsoft als Most Valuable Professional (MVP) für C# ausgezeichnet."
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Roberto"),
                            Description =
                                @"<strong>Roberto Danti</strong> ist begeisterter .NET-Entwickler und Senjor Software Developer bei der GUTSCH-ONLINE Software GmbH in Engen."
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Gregor"),
                            Description =
                                @"<strong>Gregor Biswanger</strong> ist Microsoft MVP für Client App Dev und Arbeitet als Solution Architect und Silverlight Experte bei der Firma impuls Informationsmanagement GmbH aus Nürnberg. Seine Schwerpunkte liegen im Bereich der .NET-Architektur, XAML und agilen Prozessen. 

Gregor ist auch freier Autor, Speaker und Microsoft CLIPler der INdotNET (Ingolstädter .NET Developers Group)."
                        },
                    new Speaker
                        {
                            Id = Guid.NewGuid(),
                            PersonId = GetPersondIdByName("Constantin"),
                            Description =
                                @"Constantin arbeitet als Anwendungsarchitekt und Entwickler bei der Freudenberg Forschungsdienste KG. Dort beschäftigt er sich hauptsächlich mit dem Design und der Entwicklung von Web-Informationssystemen und Datenbanken. Seit seinem Studium der Wirtschaftsinformatik gilt sein besonderes Interesse darüber hinaus allen aktuellen Themen im Microsoft .NET Umfeld, insbesondere aber dem Thema Softwarearchitektur. 

Er ist MCSD, MCITP Database Developer und MCPD Web + Enterprise Application Developer. 2010 und 2011 wurde er von Microsoft zum Most Valuable Professional (MVP) für SQL Server ernannt. 

Er engagiert sich zusätzlich im Vorstand des Just Community e.V. (<a href=""http://www.justcommunity.de"">http://www.justcommunity.de</a>) und als Leiter der .NET User Group Frankfurt (<a href=""http://www.dotnet-ug-frankfurt.de"">http://www.dotnet-ug-frankfurt.de</a>). Sein Blog finden Sie unter: <a href=""http://kostjaklein.wordpress.com"">http://kostjaklein.wordpress.com</a>"
                        }
                };

            using (var repository = XmlRepository.XmlRepository.GetInstance<Speaker>())
            {
                repository.DeleteAllOnSubmit();
                repository.SubmitChanges();

                foreach (var speaker in _speakers)
                {
                    repository.SaveOnSubmit(speaker);
                }
                repository.SubmitChanges();
            }
        }

        private void CreateLokationRepo()
        {
            _locations = new List<Location>
                {
                    new Location
                        {
                            Id = Guid.NewGuid(),
                            Name = "Weinstube Pfohl",
                            Address = "Salmannsweilergasse 11; 78462 Konstanz",
                            Capacity = 30
                        },
                    new Location
                        {
                            Id = Guid.NewGuid(),
                            Name = "Kultur- und Sportzentrum DREISPITZ",
                            Address = "Pestalozzistrasse 17; Postfach 1228; 8280 Kreuzlingen",
                            Capacity = 200
                        },
                    new Location
                        {
                            Id = Guid.NewGuid(),
                            Name = "Fachhochschule Nürnberg",
                            Address = "Bahnhofstraße 87; 90402 Nürnberg",
                            Capacity = 0
                        },
                    new Location
                        {
                            Id = Guid.NewGuid(),
                            Name = "Hotel Restaurant Bahnhof Post",
                            Address = "Nationalstrasse 2; 8280 Kreuzlingen",
                            Capacity = 20
                        },
                    new Location
                        {
                            Id = Guid.NewGuid(),
                            Name = "Restaurant Quellenhof",
                            Address = "Alleeweg 12; 8280 Kreuzlingen",
                            Capacity = 20
                        },
                    new Location
                        {
                            Id = Guid.NewGuid(),
                            Name = "Restaurant Seerhein",
                            Address = "Spanierstraße 3; 78467 Konstanz",
                            Capacity = 20
                        },
                };

            using (var repository = XmlRepository.XmlRepository.GetInstance<Location>())
            {
                repository.DeleteAllOnSubmit();
                repository.SubmitChanges();

                foreach (var speaker in _locations)
                {
                    repository.SaveOnSubmit(speaker);
                }
                repository.SubmitChanges();
            }
        }

        public void CreateEventRepo()
        {
            _events = new List<Event>
                {
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"21. Treffen mit Thorsten Hans und MSBuild",
                            Teaser =
                                @"Das 21. .NET-Stammtisch Treffen findet mit Thorsten Hans und dem Thema ""MSBuild"" in der Weinstube Pfohl statt.",
                            Description =
                                @"<b>MSBuild</b> ist das Werkzeug zum Erstellen von .NET Projekten. Nach einer kurzen Einführung in die Thematik, geht es von einfachen Beispielen, über eigene MSBuild Tasks hin zu den wichtigen neuen Features von MSBuild 4.0. Thorsten Hans zeigt wie leicht und schnell man MSBuild erlernen kann und das erlernte in der Praxis einsetzen kann.

Zusätzlich zu dem tollen Thema gibt es eine <b>freudige Neuigkeit</b> und ein <b>Windows 7 Ultimate</b> zu gewinnen.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2010, 10, 13, 19, 00, 00),
                            ToDate = new DateTime(2010, 10, 13, 22, 00, 00),
                            LocationId = GetLocationIdByName("Weinstube Pfohl"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Thorsten")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"22. Treffen: .NET Coding Dojo mit Ilker Cetinkaya",
                            Teaser =
                                @"Beim 22. Treffen findet ein <b>.NET Coding Dojo</b> mit mit <b>Ilker Cetinkaya</b> statt",
                            Description =
                                @"Ein <b>.NET Coding Dojo</b> ist eine lustige interaktive Lernrunde, bei der zusammen eine kleine Programmieraufgabe gelößt wird, während einer die zusammen erarbeiteten Lösungen umsetzt. Ziel ist es zusammen etwas über Programmierpraktiken erlernen und am Ende eine lauffähige Software erstellt zu haben.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2010, 11, 10, 19, 00, 00),
                            ToDate = new DateTime(2010, 11, 10, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Ilker")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"23. Treffen mit Thomas Schissler und 'Scrum'",
                            Teaser =
                                @"Das 23. .NET-Stammtisch Treffen findet mit<b> Thomas Schissler</b> und dem Thema <b>Scrum</b> statt",
                            Description =
                                @"<b>Scrum</b> erfreut sich für das Management von agilen Projekten immer größerer Beliebtheit. Doch von der Theorie zur Praxis ist trotz der oft beschworenen Einfachheit von SCRUM ein weiter Weg. Der Vortrag erläutert zunächst die Grundlagen von Scrum. Anschließend werden Best Practices aus allen Projektphasen auf Basis des Team Foundation Servers 2010 erläutert. Dabei werden konkrete und praktische Ratschläge zu Bereichen wie Anforderungsmanagement, Priorisierung, Teamorganisation und mehr gegeben. Der Vortrag beantwortet auch Fragen wie ""Lohnt sich der Aufwand für ein Sprintplanungs-Meeting mit dem gesamten Team?"", ""Wie organisiere ich mein Team und welche Herausforderungen entstehen dabei?"" oder ""Welche Eigenschaften muss ein Product Owner mitbringen um diese Rolle erfolgreich auszufüllen?"". Insgesamt also ein Vortrag der vor allem Vorgehensweisen und Methoden erläutert, aber auch deren praktische Umsetzung aufzeigt..

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2010, 12, 08, 19, 00, 00),
                            ToDate = new DateTime(2010, 12, 08, 22, 00, 00),
                            LocationId = GetLocationIdByName("Weinstube Pfohl"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Thomas")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"24. Treffen mit Jürgen Gutsch und '[bitte wählen]' ;-)",
                            Teaser =
                                @"Das 24. .NET-Stammtisch Treffen findet mit<b> Jürgen Gutsch</b> und dem Thema <b>[bitte wählen]</b> statt ;-)",
                            Description =
                                @"Da das Thema noch nicht feststeht, könnt Ihr euch das Thema auswählen. Dazu habe ich eine kleine Doodle-Umfrage gestartet.

Bitte folge diesem Link, um an der Umfrage teilzunehmen: 
<a href=""http://doodle.com/hc4y8vv82c9pd53q"">http://doodle.com/hc4y8vv82c9pd53q</a> ",
                            FromDate = new DateTime(2011, 1, 12, 19, 00, 00),
                            ToDate = new DateTime(2011, 1, 12, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"25. Treffen mit Thomas Claudius Huber und 'Silverlight Magic: Hardwarenahe Effekte mit Pixelshadern'",
                            Teaser =
                                @"Das 25. .NET-Stammtisch Treffen findet mit<b> Thomas Claudius Huber</b> und dem Thema <b>Silverlight Magic: Hardwarenahe Effekte mit Pixelshadern</b> statt",
                            Description =
                                @"In der WPF 3.5 SP1 wurden die sog. Bitmap-Effekte durch Pixelshader abgelöst. Auch in Silverlight lassen sich mit Pixelshadern eigene Effekte erstellen, um die Darstellung von UIElemente beliebig anzupassen. In diesem Vortrag zeigt Thomas nach einem Blick auf die Geschichte der Effekte in WPF/Silverlight die hardwarenahe Programmierung von Pixelshadern in der High Level Shader Language (HLSL). Die erstellten Effekte werden in Silverlight genutzt um beeindruckende Effekte zu erstellen.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 2, 9, 19, 00, 00),
                            ToDate = new DateTime(2011, 2, 9, 22, 00, 00),
                            LocationId = GetLocationIdByName("Weinstube Pfohl"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Thomas Claudius")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"26. Treffen mit Golo Roden, David Thielke und 'Code Qualität'",
                            Teaser =
                                @"Das 26. .NET-Stammtisch Treffen findet mit<b> Golo Roden, David Thielke </b> und dem Thema <b>Code Qualität</b> statt",
                            Description =
                                @"Code zu schreiben, ist keine Kunst – doch qualitativ hochwertigen Code zu schreiben, durchaus. Zum Glück sind Entwickler dabei heutzutage nicht mehr auf sich allein gestellt, sondern werden von Visual Studio in vielerlei Hinsicht unterstützt. David Tielke und Golo Roden zeigen in dieser Session, welche Vielzahl an Möglichkeiten es in Visual Studio 2010 gibt, die Qualität von Code zu messen, zu analysieren und zu verbessern, und was sich gegenüber den Vorgängerversionen 2005 und 2008 geändert hat.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 3, 9, 19, 00, 00),
                            ToDate = new DateTime(2011, 3, 9, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Golo"), GetSpeakerIdByPersonName("David")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"28. Treffen mit Jürgen Gutsch, Peter Bucher und einem .NET Coding Dojo",
                            Teaser =
                                @"Das 28. Treffen findet mit Jürgen Gutsch, Peter Bucher  und eine .NET-Coding-Dojo statt",
                            Description =
                                @"Ein <b>.NET Coding Dojo</b> ist eine lustige interaktive Lernrunde, bei der zusammen eine kleine Programmieraufgabe gelößt wird, während einer die zusammen erarbeiteten Lösungen umsetzt. Ziel ist es zusammen etwas über Programmierpraktiken erlernen und am Ende eine lauffähige Software erstellt zu haben.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 5, 11, 19, 00, 00),
                            ToDate = new DateTime(2011, 5, 11, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen"), GetSpeakerIdByPersonName("Peter")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"29. Treffen mit Jürgen Gutsch und TDD",
                            Teaser =
                                @"Das 29. Treffen findet mit Jürgen Gutsch  und dem Thema Test Driven Developement statt",
                            Description =
                                @"Es ist nicht nur wichtig Software mit Unit-Tests automatisiert zu testen, sondern dem Kunden/Vorgesetzten zu bestätigen: ""Ich habe Deine Anforderungen verstanden und diese Testergebnisse sagen Dir, dass alle deine Anforderungen erfüllt sind. Mein Job ist vorerst erledigt"" 

An diesem treffen zeigt Jürgen die Grundlagen von Unit-Tests und Testgetriebener Entwicklung anhand von NUnit und MSTest. Nachdem eine kleine Anwendung per TDD entwickelt worden ist, zeigt Jürgen wofür Unit-Tests noch alles zu gebrauchen sind. Ein Ausflug in die Grundlagen von BDD ist ebenfalls mit drin.

Soltle noch Zeit übrig sein, geht Jürgen kurz auf weitere exotische frameworks, wie MSpec ein.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 6, 8, 19, 00, 00),
                            ToDate = new DateTime(2011, 6, 8, 22, 00, 00),
                            LocationId = GetLocationIdByName("Weinstube Pfohl"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"30. Treffen mit Constantin Klein und ""SQL Server für Entwickler""",
                            Teaser =
                                @"Unter dem Codenamen ""Denali"" steht das nächste Major Release des Microsoft SQL Servers bereits in den Startlöchern. Und dennoch haben es viele Neuerungen der Vorgängerversionen 2005 und 2008 (R2) noch nicht in den Arbeitsalltag der Entwickler geschafft. Wenn Ihre Software auf den MS SQL Server als Datenbankplattform setzt und Sie die Anforderungen Ihrer Software mit den Fähigkeiten des MS SQL Server optimal unterstützen wollen, dann sind Sie hier richtig.",
                            Description =
                                @"Neben einigen ausgewählten Tipps und Tricks werden verschiedene (Sprach-)Neuerungen des SQL Server 2005 + 2008 vorgestellt und ein Ausblick auf die mit ""Denali"" zu erwartenden Verbesserungen gegeben. Ein besonderer Schwerpunkt wird dabei auf den Themen Filestream und der Verarbeitung von Geodaten liegen..

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 7, 13, 19, 00, 00),
                            ToDate = new DateTime(2011, 7, 13, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Constantin")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"31. Treffen mit Ralf Westphal und ""Slice me nice – Produktiv, schnell, zufrieden""",
                            Teaser =
                                @"Anforderungen müssen einfach nur weggeschafft werden? Nein. Wenn Sie Anforderungen einfach nur irgendwie wegschaffen, dann schaffen Sie nicht effizient. Da hilft auch keine Priorisierung im Backlog. Für maximale Produktivität und auch für Ihre Zufriedenheit als Entwickler am Ende jedes einzelnen Projekttages ist mehr nötig.",
                            Description =
                                @"Der Vortrag erklärt, wie Sie mit Grundbegriffen der Theory of Constraints (TOC) wie auch der Softwarearchitektur die Implementierung „in Fluss bringen“. Bereiten Sie Ihre Entwicklung im Team durch rigoroses Zerschneiden von Anforderungen in dünne Scheiben und  so vor, dass Sie Ihr Team optimal nutzen.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 8, 10, 19, 00, 00),
                            ToDate = new DateTime(2011, 8, 10, 22, 00, 00),
                            LocationId = GetLocationIdByName("Weinstube Pfohl"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Ralf")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"32. Treffen mit Golo Roden und Agil 2.0 – das Agile Development Framework (ADF)",
                            Teaser =
                                @"Scrum, XP & Co – bestehende agile Methoden bedienen jeweils verschiedene Zielgruppen und Aspekte der Softwareentwicklung, doch eine einzelne agile Methode genügt in der Praxis häufig nicht. Was also fehlt, ist ein umfassendes Rahmenwerk, das die erfolgreichen Elemente der bestehenden agilen Methoden vereint, das jedoch – wenn erforderlich – auch eigene Pfade einschlägt.",
                            Description =
                                @"Das Agile Development Framework (ADF) tritt an, dieses Problem zu lösen, indem es Individuen, Teams und Unternehmen während des gesamten Entwicklungsprozesses von qualitativ hochwertiger Software unterstützt, unter Berücksichtigung der einzelnen Rollen und deren jeweiligen Interessen.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 9, 14, 19, 00, 00),
                            ToDate = new DateTime(2011, 9, 14, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Golo")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"33. Treffen mit Roberto Danti und NHibernate",
                            Teaser =
                                @"Roberto stellt uns den schnelle und beliebten OR-Mapper 'NHibernate' vor und die Konfiguration mit Fluent.NHibernate.",
                            Description =
                                @"(Vorläufige Beschreibung: Roberto stellt uns den schnelle und beliebten OR-Mapper 'NHibernate' vor und die Konfiguration mit Fluent.NHibernate).

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 10, 12, 19, 00, 00),
                            ToDate = new DateTime(2011, 10, 12, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Roberto")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"34. Treffen mit Jürgen Gutsch und Vier Augen - Von Codereview und Pair Programming",
                            Teaser =
                                @"Ein Themenwunssch aus dem .NET-Stammtisch: 
Codereview - Warum, wer, weswegen? Wie oft, wann ist genug?",
                            Description =
                                @"Vier Augen sehen mehr als zwei, soviel steht fest, aber wie sollte ein Codereview konkret aussehen? Jürgen zeigt in diesem Vortrag die Vorteile des Codereviews und wie man Codereviews angehen sollte. Im zweiten Teil zeigt Jürgen als weitere Steigerung: das Pair Programming. Anhand einer Demonstration wie man in Paaren entwickelt und wie effektiv man dabei sein kann.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 11, 11, 19, 00, 00),
                            ToDate = new DateTime(2011, 11, 11, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"35. Treffen mit André Lämmer und dem Thema .NET Micro Framework",
                            Teaser =
                                @"Im sommer kam das Gadgeteer Starter Pack ""FEZ Spider Starter Kit"" heraus, dass man mit dem .NET Mircro Framework anprogrammieren kann",
                            Description =
                                @"André Lämmer zeigt uns die Komponenten des Starter Pack und erklärt was man damit machen und wie man es mit C# anprogrammieren kann.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2011, 12, 14, 19, 00, 00),
                            ToDate = new DateTime(2011, 12, 14, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("André")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"36. Treffen mit Jürgen Gutsch und ReSharper",
                            Teaser =
                                @"Bei vielen .NET-Entwicklern ist der ReSharper zu einem festen Bestandteil im Visual Studio geworden. Das Tool, das ursprünglich als Refactoring-Werkzeug konzipiert wurde, kann heute sehr viel mehr und unterstützt die Produktivität der .NET-Entwickler in vielerlei Hinsicht",
                            Description =
                                @"Jürgen Gutsch präsentiert in dieser Session die Benutzung und den Funktionsumfang des ReSharper 6.1 und zeigt einige Tipps und Tricks die jeder Nutzer wissen sollte.

Zu dieser Session stellt Jetbrains übrigens eine Lizenz des ReSharpers zur Verlosung zur Verfügung. Wer in dem Vortrag gut aufpasst, kann am Ende einen ReSharper mit nach Hause nehmen.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 1, 11, 19, 00, 00),
                            ToDate = new DateTime(2012, 1, 11, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"37. Treffen mit Jürgen gutsch und NuGet",
                            Teaser =
                                @"Jürgen Gutsch zeigt die Vorteile und die Verwendung von NuGet, wie man eigene NuGet-Pakete erstellen kann und wie man NuGet im eigenen Unternehmen implementieren kann.",
                            Description =
                                @"Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 2, 8, 19, 00, 00),
                            ToDate = new DateTime(2012, 2, 8, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Quellenhof"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"38. Treffen mit Golo Roden und Node.js",
                            Teaser =
                                @"Golo zeigt uns in einer Einführung die Funktionsweise und die Entwicklung von und mit Node.js",
                            Description =
                                @"Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 3, 14, 19, 00, 00),
                            ToDate = new DateTime(2012, 3, 14, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Golo")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"39. Treffen mit Gregor Biswanger und Windows 8 und WinRT - Erschaffe eine neue Welt",
                            Teaser =
                                @"Mit Windows 8 steht im Gegensatz zu den bisherigen Windows-Versionen, die Bedienung mittels Touchscreen im Vordergrund. Dazu wurde eine neue Oberfläche (MetroUI) als Startscreen integriert, die sich an der Gestaltung von Windows Phone 7 orientiert. Diese läuft unter einer neuen Laufzeitumgebung namens Windows Runtime (WinRT).
Dieser Vortrag gibt einen Überblick über die Neuerungen von Windows 8 und zeigt was alles für den Start für C#-Entwickler wichtig ist.",
                            Description =
                                @"<iframe width=""420"" height=""315"" src=""http://www.youtube.com/embed/81xOe0_0_DA"" frameborder=""0"" allowfullscreen></iframe>

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 4, 11, 19, 00, 00),
                            ToDate = new DateTime(2012, 4, 11, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Gregor")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"40. Treffen mit Roberto Danto und Design Patterns",
                            Teaser =
                                @"Wundermittel oder Überflüssig? Diese Frage versuchen wir beim nächsten Stammtisch am 09 Mai nachzugehen.
Nach eine Einführung und Vorstellung der gängige Entwurf Mustern, werden wir in eine lockere Diskussionsrunde über Sinn und Unsinn von Entwurf Muster diskutieren.",
                            Description =
                                @"Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 5, 9, 19, 00, 00),
                            ToDate = new DateTime(2012, 5, 9, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Roberto")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"41. Treffen mit Jürgen Gutsch und Robocode für .NET",
                            Teaser =
                                @"Robocode ist eigentlich ein kleines Spiel um Java zu lernen. Man programmiert sich kleine lustige Panzer (Robots) die auf bestimmte Situationen reagieren müssen und andere Robots abschießen müssen.",
                            Description =
                                @"Seit einigen Monaten ist es nun auch mit .NET möglich, Robots zu bauen und zur Verfügung zu stellen.

In diesem Treffen möchte ich kurz zeigen, wie man Robocode auf dem eigenen Rechner zum Laufen bringt.
Anschließend zeige ich die Entwicklung eigener Robots.

Wer möchte, kann seinen eigenen Laptop mitbringen und parallel mitarbeiten. So können wir am Ende unsere Robots gegeneinander spielen lassen.

Am Mittwoch gibt es auch wieder etwas zu gewinnen. Dank Pluralsight dürfen wir ein Monatsabonnement für den Zugang zu den ""hardcore developer trainings"" verlosen :-)

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 6, 13, 19, 00, 00),
                            ToDate = new DateTime(2012, 6, 13, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"42. Treffen mit Jürgen Gutsch und einem Coding Dojo",
                            Teaser =
                                @"An diesem Treffen werden wir wieder ein Coding Dojo veranstalten und hoffen auf eine rege Teilnahme. ",
                            Description =
                                @"Da dieses und das nächste Mal die Räume in Kreuzlingen besetzt sind, treffen wir uns mal wieder in Konstanz, im Restaurant Seerhein.

Am Mittwoch gibt es auch wieder etwas zu gewinnen. Dank Pluralsight dürfen wir ein Monatsabonnement für den Zugang zu den ""hardcore developer trainings"" verlosen :-)

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 7, 11, 19, 00, 00),
                            ToDate = new DateTime(2012, 7, 11, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Seerhein"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"43. Treffen mit Gregor Biswanger und Silverlight 5 – Silverlight aktiviert Abwehrkräfte",
                            Teaser =
                                @"Gregor Biswanger stellt uns bei diesem Treffen Silverlight 5 vor.",
                            Description =
                                @"Während Spekulationen der Medienwelt den Tod von Silverlight hervorrufen, ist nun endlich die neue Version von Silverlight veröffentlicht worden. Diese zeigt sich allerdings, alles andere als Lebensmüde. Mit der neuen Version sind nun lang erwartete XAML-Features hinzugekommen. Der Vortrag demonstriert die Highlights von Silverlight 5 und zeigt zudem die besonderen Abwehrkräfte gegenüber HTML 5.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 8, 8, 19, 00, 00),
                            ToDate = new DateTime(2012, 8, 8, 22, 00, 00),
                            LocationId = GetLocationIdByName("Restaurant Seerhein"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Gregor")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"44. Treffen mit Jürgen und Roberto; Möglichkeiten mit MVC Web API und der Cloud",
                            Teaser =
                                @"An diesem Treffen zeigt Jürgen was mit ASP.NET MVC Web API möglich ist und wie einfach und schnell, flexible und testbare Webdienste umgesetzt sind. Anschließend Zeigt Roberto, wie dieser Dienst in der Cloud (Azure oder AppHarbour) eingerichtet werden kann.",
                            Description =
                                @"Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 9, 12, 19, 00, 00),
                            ToDate = new DateTime(2012, 9, 12, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen"),GetSpeakerIdByPersonName("Jürgen")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"45. Treffen mit Urs Enzler und Daniel Marbach und dem Thema Appccelerate your .Net Application development",
                            Teaser =
                                @"Jeden Tag das selbe Spiel. Wir schreiben den gleichen Infrastrukturcode immer und immer wieder. Dabei fühlen wir uns eigentlich der Codeduplizierung schuldig und schwören uns es beim nächsten Mal nicht mehr so zu machen. Täglich grüsst das Murmeltier. Doch vorbei sind diese Zeiten! ",
                            Description =
                                @"Mit <b>Appccelerate</b> beschleunigen wir deine Applikationsentwicklung bis zum Überschall. Durch den Einsatz von Startup und Shutdown Komponenten, lose gekoppelten Events und Statemachines bleibt dein Code wart- und testbar und scheut sich nicht vor Erweiterungen. Tauche mit Urs Enzler und Daniel Marbach in die Welt von Appccelerate und entdecke dass auch Fahrstühle Gefühle besitzen können! 
<a href=""www.appccelerate.com"">www.appccelerate.com </a>

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 11, 14, 19, 00, 00),
                            ToDate = new DateTime(2012, 11, 14, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Daniel"),GetSpeakerIdByPersonName("Urs")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"46. Treffen mit Golo Roden und Javascript für C# Entwickler",
                            Teaser =
                                @"Golo Roden gibt an diesem Treffen einen Javascript Crashkurs für C# Entwickler",
                            Description =
                                @"Seit Monaten bereiten Sie sich auf Windows 8 und WinRT vor. Nun hat gerade Ihr wichtigster Kunde angerufen, um Ihnen den Auftrag zur Entwicklung einer entsprechenden Anwendung zu erteilen. Ihr anfänglicher Stolz ist jedoch schnell Ernüchterung gewichen, als die Anforderung genannt wurde, dass die Anwendung in JavaScript geschrieben werden müsse ... Diese Sprache haben Sie bislang nämlich vollständig außer Acht gelassen. Was Sie jetzt brauchen, ist ein JavaScript-Crashkurs für C#-Entwickler, der Ihnen auf die Sprünge hilft. Golo Roden stellt Ihnen in zwei Stunden (fast) alles vor, was Sie über JavaScript wissen müssen, und zeigt - ganz nebenbei - dass JavaScript-Entwicklung nicht bedeutet, steinzeitlich mit vi auf der Konsole arbeiten zu müssen.

Leider ausgefallen und durch eine FAQ-Session mit Jürgen ersetzt

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2012, 12, 12, 19, 00, 00),
                            ToDate = new DateTime(2012, 12, 12, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Daniel"),GetSpeakerIdByPersonName("Urs")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"47. Treffen mit Roberto Danti und Windows Azure",
                            Teaser =
                                @"Roberto stellt Windows Azure und die Cloud vor. Es werden Dienste und Möglichkeiten der Cloud präsentiert und mit Beispiele und Demos, werden Architektur und Anforderungen an Software für die Cloud vorgestellt.",
                            Description =
                                @"Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2013, 1, 9, 19, 00, 00),
                            ToDate = new DateTime(2013, 1, 9, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Roberto")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"48. Treffen mit Jürgen Gutsch und Entwicklung eine Moile optimierten Community Webiste",
                            Teaser =
                                @"Jürgen stellt bei diesem Treffen die neue Website des .NET-Stammtisch vor und zeigt deren Entwicklung",
                            Description =
                                @"In diesem Code-Only-Vortrag wird gezeigt, wie man mit Hilfe von HTML5, CSS3 auf ASP.NET MVC4 und etwas Javascript (JQuery und knockout.js) eine Web Application schreiben kann die auch mobile Endgeräte optimiert ist. 

Der Vortrag und die gezeigten Beispiele basieren aus dem aktuellen Projekt des .NET-Stammtisch Konstanz-Kreuzlingen, welches zum Ziel hat die Usergroup Termine und News einfach und schnell an die eigenen Mitglieder zu verteilen.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2013, 2, 13, 19, 00, 00),
                            ToDate = new DateTime(2013, 2, 13, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid>  {GetSpeakerIdByPersonName("Jürgen")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"1. .NET-Stammtisch Code-Camp mit einem Windows8 Hackathon",
                            Teaser =
                                @"Der erste 1. .NET-Stammtisch Code-Camp findet mit einem Hackthon rund um die App-Entwicklung für Windows 8 statt.",
                            Description =
                                @"Alle Teilnehmer sollten neben einem eigenen PC mit Windows 8 und einer Version von Visual Studio 2012 auch Kenntnisse in HTML5/JS bzw. .NET/Silverlight/XAML/C# mitbringen. Durch die professionelle Unterstützung seitens Microsoft lohnt sich die Teilnahme auch für Entwickler, die bislang kaum Kontakt mit der Programmierung von Apps hatten.

Das Ziel ist es möglichst viele Apps zu entwickeln und Entwickler, die an dem ein oder anderem Problem sitzen, voran zu bringen. Wir haben hier die Möglichkeit in einer lockeren Atmosphäre, Probleme bei der App-Entwicklung oder über Aufgaben und Konzepte zu diskutieren und diese dann möglichst weit zu treiben",
                            FromDate = new DateTime(2013, 3, 23, 09, 00, 00),
                            ToDate = new DateTime(2013, 3, 23, 17, 00, 00),
                            LocationId = GetLocationIdByName("Kultur- und Sportzentrum DREISPITZ"),
                            SpeakerIds = new List<Guid> {GetSpeakerIdByPersonName(".NET-Stammtisch")}
                        },
                    new Event
                        {
                            Id = Guid.NewGuid(),
                            Title = @"51. Treffen mit Constantin Klein und SQL Server 2012 - News für Datenbankentwickler",
                            Teaser =
                                @"Constantin Klein, aka. Kostja, zeigt bei diesem Treffen SQL Server 2012 - News für Datenbankentwickler.",
                            Description =
                                @"Seit dem Release des SQL Server 2012 steht die nächste Major Version des Microsoft Datenbankservers zur Verfügung. Doch was sind die wichtigsten Neuerungen? Wo ergeben sich neue Lösungsszenarien und was ist insbesondere für Entwickler von Interesse? Diese Session soll einen kompakten Überblick über viele Neuerungen geben und dabei die Highlights für Entwickler besonders hervorheben.

Anschließend wird wie immer beim gemütlichen Bierchen weiter diskutiiert :-)",
                            FromDate = new DateTime(2013, 5, 8, 19, 00, 00),
                            ToDate = new DateTime(2013, 5, 8, 22, 00, 00),
                            LocationId = GetLocationIdByName("Hotel Restaurant Bahnhof Post"),
                            SpeakerIds = new List<Guid> {GetSpeakerIdByPersonName("Constantin")},
                        }
                };

            using (var repository = XmlRepository.XmlRepository.GetInstance<Event>())
            {
                repository.DeleteAllOnSubmit();
                repository.SubmitChanges();

                foreach (var @event in _events)
                {
                    repository.SaveOnSubmit(@event);
                }
                repository.SubmitChanges();
            }
        }

        private Guid GetLocationIdByName(string name)
        {
            return _locations.FirstOrDefault(x => x.Name == name).Id;
        }

        private Guid GetPersondIdByName(string name)
        {
            return _persons.FirstOrDefault(x => x.FirstName == name).Id;
        }


        private Guid GetSpeakerIdByPersonName(string name)
        {
            return _speakers.FirstOrDefault(x => x.PersonId == _persons.FirstOrDefault(y => y.FirstName == name).Id).Id;
        }

    }
}
