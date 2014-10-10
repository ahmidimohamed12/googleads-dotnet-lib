// Copyright 2013, Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Author: api.anash@gmail.com (Anash P. Oommen)

using Google.Api.Ads.Dfp.Lib;
using Google.Api.Ads.Dfp.v201306;
using Google.Api.Ads.Dfp.Util.v201306;

using System;

namespace Google.Api.Ads.Dfp.Examples.CSharp.v201306 {
  /// <summary>
  /// This code example updates contact addresses. To determine which contacts
  /// exist, run GetAllContacts.cs.
  ///
  /// Tags: ContactService.updateContacts
  /// </summary>
  class UpdateContacts : SampleBase {
    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This code example updates contact comments. To determine which contacts " +
            "exist, run GetAllContacts.cs.";
      }
    }

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args) {
      SampleBase codeExample = new UpdateContacts();
      Console.WriteLine(codeExample.Description);
      codeExample.Run(new DfpUser());
    }

    /// <summary>
    /// Run the code example.
    /// </summary>
    /// <param name="user">The DFP user object running the code example.</param>
    public override void Run(DfpUser user) {
      // Get the ContactService.
      ContactService contactService =
          (ContactService) user.GetService(DfpService.v201306.ContactService);

      // Set the ID of the contact to update.
      long contactId = long.Parse(_T("INSERT_CONTACT_ID_HERE"));

      try {
        // Get the contact.
        Contact contact = contactService.getContact(contactId);

        // Update the address of the contact.
        contact.address = "123 New Street, New York, NY, 10011";

        // Update the contact on the server.
        Contact[] contacts = contactService.updateContacts(new Contact[] {contact});

        // Display results.
        foreach (Contact updatedContact in contacts) {
          Console.WriteLine("Contact with ID \"{0}\", name \"{1}\", and comment \"{2}\" was " +
              "updated.", updatedContact.id, updatedContact.name, updatedContact.comment);
        }
      } catch (Exception ex) {
        Console.WriteLine("Failed to update contacts. Exception says \"{0}\"", ex.Message);
      }
    }
  }
}
