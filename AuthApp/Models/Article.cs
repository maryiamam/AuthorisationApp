using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthApp.Models
{
    public class Article
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }

        public static List<Article> GetTestData()
        {
            var testData = new List<Article>
            {
                new Article
                {
                    Name = "Who is user",
                    Author = "Wiki",
                    Text = "A user is a person who user a computer or network service. " +
                    "Users generally use a system or a software product without the " +
                    "technical expertise required to fully understand it.",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "What does user usually have",
                    Author = "Masha",
                    Text = "A user often has a user account and is identified to the system " +
                    "by a username (or user name).",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Software",
                    Author = "Lesha",
                    Text = "Some software products provide services to other systems and have " +
                    "no direct end user.",
                    CreatedOn = new DateTime(2014, 2, 12)
                },
                new Article
                {
                    Name = "End user",
                    Author = "Wiki",
                    Text = "End users are the ultimate human user (also referred to as operators) " +
                    "of a software product. The term is used to abstract and distinguish those who " +
                    "only use the software from the developers of the system, who enhance the software " +
                    "for end users.",
                    CreatedOn = new DateTime(2012, 1, 23)
                },
                new Article
                {
                    Name ="User-centered design",
                    Author = "Petya",
                    Text = "In user-centered design, it also distinguishes the software operator from " +
                    "the client who pays for its development and other stakeholders who may not directly " +
                    "user the software, but help establish its requirements.",
                    CreatedOn = new DateTime(1915, 2, 21)
                },
                new Article
                {
                    Name = "Designing the interface",
                    Author = "Masha",
                    Text = "This abstraction is primarily useful in designing the user interface, and refers " +
                    "to a relevant subset of characteristics that most expected users would have in common.",
                    CreatedOn = new DateTime(2006, 11, 11)
                },
                new Article
                {
                    Name = "The types of users",
                    Author = "Lesha",
                    Text = "In user-centered design, personas are created to represent the types of users. It " +
                    "is sometimes specified for each persona which types of user interfaces it is comfortable " +
                    "with (due to previous experience or the interface's inherent simplicity), and what " +
                    "technical expertise and degree of knowledge it has in specific fields or disciplines. ",
                    CreatedOn = new DateTime(2012, 12, 22)
                },
                new Article
                {
                    Name = "End-user category",
                    Author = "Masha",
                    Text = " When few constraints are imposed on the end-user category, especially when " +
                    "designing programs for user by the general public, it is common practice to expect " +
                    "minimal technical expertise or previous training in end users.",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Graphical interfaces",
                    Author = "Lesha",
                    Text = " In this context, graphical user interfaces (GUIs) are usually preferred to " +
                    "command-line interfaces (CLIs) for the sake of usability.",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Significant knowledge of a programming language",
                    Author = "Masha",
                    Text = "The end-user development discipline blurs the typical distinction between users" +
                    " and developers. It designates activities or techniques in which people who are not " +
                    "professional developers create automated behavior and complex data objects without" +
                    " significant knowledge of a programming language.",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Ultimate human users",
                    Author = "Lesha",
                    Text = "End users are the ultimate human user (also referred to as operators) of a software " +
                    "product. The term is used to abstract and distinguish those who only use the software from" +
                    " the developers of the system, who enhance the software for end users.",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Software agent",
                    Author = "Masha",
                    Text = "Systems whose actor is another system or a software agent have no direct end user.",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Account",
                    Author = "Vasya",
                    Text = "A user's account allows a user to authenticate to a system and potentially to receive " +
                    "authorization to access resources provided by or connected to that system; however, " +
                    "authentication does not imply authorization. ",
                    CreatedOn = new DateTime(2005, 6, 4)
                },
                new Article
                {
                    Name = "Log in",
                    Author = "Masha",
                    Text = "To log into an account, a user is typically required to authenticate oneself with a " +
                    "password or other credentials for the purposes of accounting, security, logging, and resource " +
                    "management.",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Access",
                    Author = "Olya",
                    Text = "Each user account on a multi-user system typically has a home directory, in which to " +
                    "store files pertaining exclusively to that user's activities, which is protected from access " +
                    "by other user (though a system administrator may have access). ",
                    CreatedOn = new DateTime(2010, 3, 2)
                },
                new Article
                {
                    Name = "Rules",
                    Author = "Masha",
                    Text = "Various computer operating-systems and applications expect/enforce different rules for " +
                    "the form.",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Terminology",
                    Author = "Lesha",
                    Text = "Some usability professionals have expressed their dislike of the term 'user', proposing " +
                    "it to be changed. Don Norman stated that 'One of the horrible words we use is 'users'. I am " +
                    "on a crusade to get rid of the word 'user'. I would prefer to call them 'people'.",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Psycho",
                    Author = "Masha",
                    Text = "The term drug user is often used to refer to a person who consumes an illegal " +
                    "psychoactive substance.",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Consumer",
                    Author = "Lesha",
                    Text = "A consumer is a person or organization that user economic services or commodities.",
                    CreatedOn = new DateTime(2007, 2, 14)
                },
                new Article
                {
                    Name = "Article",
                    Author = "Masha",
                    Text = "This article is about websites in general. For the Internet domain .website, see List of " +
                    "Internet top-level domains.Not to be confused with WebCite.",
                    CreatedOn = new DateTime(2006, 7, 16)
                },
                new Article
                {
                    Name = "Site",
                    Author = "Valya",
                    Text = "Websites have many functions and can be user in various fashions; a website can be a " +
                    "personal website, a commercial website for a company, a government website or a non-profit " +
                    "organization website. Websites are typically dedicated to a particular topic or purpose, " +
                    "ranging from entertainment and social networking to providing news and education.",
                    CreatedOn = new DateTime(2011, 12, 9)
                },
                new Article
                {
                    Name = "Documents",
                    Author = "Masha",
                    Text = "Web pages, which are the building blocks of websites, are documents, typically " +
                    "composed in plain text interspersed with formatting instructions of Hypertext Markup " +
                    "Language (HTML, XHTML). ",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Incorporation",
                    Author = "Oleg",
                    Text = "They may incorporate elements from other websites with suitable markup anchors. ",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Protocol",
                    Author = "Masha",
                    Text = "Web pages are accessed and transported with the Hypertext Transfer Protocol (HTTP), " +
                    "which may optionally employ encryption (HTTP Secure, HTTPS) to provide security and privacy " +
                    "for the user. ",
                    CreatedOn = new DateTime(1997, 9, 12)
                },
                new Article
                {
                    Name = "Markup",
                    Author = "Nikolay",
                    Text = "The user's application, often a web browser, renders the page content according to " +
                    "its HTML markup instructions onto a display terminal.",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Pages",
                    Author = "Masha",
                    Text = "Hyperlinking between web pages conveys to the reader the site structure and guides " +
                    "the navigation of the site, which often starts with a home page containing a directory of " +
                    "the site web content.",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Registration",
                    Author = "Vova",
                    Text = "Some websites require user registration or subscription to access content. ",
                    CreatedOn = new DateTime(2011, 4, 7)
                },
                new Article
                {
                    Name = "Services",
                    Author = "Masha",
                    Text = "Examples of subscription websites include many business sites, news websites, " +
                    "academic journal websites, gaming websites, file-sharing websites, message boards," +
                    " web-based email, social networking websites, websites providing real-time stock market " +
                    "data, as well as sites providing various other services.",
                    CreatedOn = new DateTime(2016, 5, 23)
                },
                new Article
                {
                    Name = "Devices",
                    Author = "Lesha",
                    Text = "As of 2016 end user can access websites on a range of devices, including desktop and " +
                    "laptop computers, tablet computers, smartphones and smart TVs.",
                    CreatedOn = new DateTime(2015, 3, 15)
                },
                new Article
                {
                    Name = "Tim Berners-Lee",
                    Author = "Masha",
                    Text = "The World Wide Web (WWW) was created in 1990 by the British CERN physicist " +
                    "Tim Berners-Lee.",
                    CreatedOn = new DateTime(1990, 1, 1)
                },
                new Article
                {
                    Name = "CERN",
                    Author = "Lesha",
                    Text = "On 30 April 1993, CERN announced that the World Wide Web would be free to use for anyone.",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Other protocols",
                    Author = "Masha",
                    Text = "Before the introduction of HTML and HTTP, other protocols such as File Transfer " +
                    "Protocol and the gopher protocol were used to retrieve individual files from a server. ",
                    CreatedOn = new DateTime(2016, 5, 22)
                },
                new Article
                {
                    Name = "Navigation",
                    Author = "Pasha",
                    Text = "These protocols offer a simple directory structure which the user navigates and " +
                    "chooses files to download. ",
                    CreatedOn = new DateTime(2013, 2, 5)
                },
                new Article
                {
                    Name = "Plain text",
                    Author = "Masha",
                    Text = "Documents were most often presented as plain text files without formatting, or were " +
                    "encoded in word processor formats.",
                    CreatedOn = new DateTime(2014, 6, 18)
                },
                new Article
                {
                    Name = "Overview",
                    Author = "Lesha",
                    Text = "Websites have many functions and can be used in various fashions; a website can be a " +
                    "personal website, a commercial website, a government website or a non-profit organization website.",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Organization work",
                    Author = "Vitya",
                    Text = "Websites can be the work of an individual, a business or other organization, and are " +
                    "typically dedicated to a particular topic or purpose. ",
                    CreatedOn = new DateTime(2006, 10, 8)
                },
                new Article
                {
                    Name = "Hyperlink",
                    Author = "Lesha",
                    Text = "Any website can contain a hyperlink to any other website, so the distinction between " +
                    "individual sites, as perceived by the user, can be blurred. ",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Languages",
                    Author = "Masha",
                    Text = " Websites are written in, or converted to, HTML (Hyper Text Markup Language) and are " +
                    "accessed using a software interface classified as a user agent. ",
                    CreatedOn = new DateTime(2003, 6, 9)
                },
                new Article
                {
                    Name = "Article1",
                    Author = "Lesha",
                    Text = " Web pages can be viewed or otherwise accessed from a range of computer-based and " +
                    "Internet-enabled devices of various sizes, including desktop computers, laptops, PDAs and " +
                    "cell phones.",
                    CreatedOn = new DateTime(2015, 5, 22)
                },
                new Article
                {
                    Name = "Web server",
                    Author = "Masha",
                    Text = "A website is hosted on a computer system known as a web server, also called an HTTP " +
                    "(Hyper Text Transfer Protocol) server. These terms can also refer to the software that runs " +
                    "on these systems which retrieves and delivers the web pages in response to requests from the " +
                    "website's users. ",
                    CreatedOn = new DateTime(2009, 1, 9)
                },
                new Article
                {
                    Name = "Apache",
                    Author = "Masha",
                    Text = "Apache is the most commonly used web server software (according to Netcraft " +
                    "statistics) and Microsoft's IIS is also commonly used. Some alternatives, such as " +
                    "Nginx, Lighttpd, Hiawatha or Cherokee, are fully functional and lightweight.",
                    CreatedOn = new DateTime(2017, 8, 23)
                }
            };
            return testData;
        }
    }
}