using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TortoiseMantis.MantisConnectReference;

namespace TortoiseMantis
{
    interface IIssuesDisplay
    {
        void SetAccountData(AccountData[] accountData);
        void SetIssueHeaderData(IssueHeaderData[] issueHeaders);
        void SetStatusMappings(ObjectRef[] statusEnum);
    }
}
