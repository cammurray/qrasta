namespace QRasta.Helpers;

public class ASTUrl
{

    private static string[] _ValidURLs = new[]
    {
        "www.attemplate.com", "www.exportants.it", "www.resetts.it",
        "www.bankmenia.com", "www.exportants.org", "www.resetts.org",
        "www.bankmenia.de", "www.financerta.com", "www.salarytoolint.com",
        "www.bankmenia.es", "www.financerta.de", "www.salarytoolint.net",
        "www.bankmenia.fr", "www.financerta.es", "www.securembly.com",
        "www.bankmenia.it", "www.financerta.fr", "www.securembly.de",
        "www.bankmenia.org", "www.financerta.it", "www.securembly.es",
        "www.banknown.de", "www.financerta.org", "www.securembly.fr",
        "www.banknown.es", "www.financerts.com", "www.securembly.it",
        "www.banknown.fr", "www.financerts.de", "www.securembly.org",
        "www.banknown.it", "www.financerts.es", "www.securetta.de",
        "www.banknown.org", "www.financerts.fr", "www.securetta.es",
        "www.browsersch.com", "www.financerts.it", "www.securetta.fr",
        "www.browsersch.de", "www.financerts.org", "www.securetta.it",
        "www.browsersch.es", "www.hardwarecheck.net", "www.shareholds.com",
        "www.browsersch.fr", "www.hrsupportint.com", "www.sharepointen.com",
        "www.browsersch.it", "www.mcsharepoint.com", "www.sharepointin.com",
        "www.browsersch.org", "www.mesharepoint.com", "www.sharepointle.com",
        "www.docdeliveryapp.com", "www.officence.com", "www.sharesbyte.com",
        "www.docdeliveryapp.net", "www.officenced.com", "www.sharession.com",
        "www.docstoreinternal.com", "www.officences.com", "www.sharestion.com",
        "www.docstoreinternal.net", "www.officentry.com", "www.supportin.de",
        "www.doctorican.de", "www.officested.com", "www.supportin.es",
        "www.doctorican.es", "www.passwordle.de", "www.supportin.fr",
        "www.doctorican.fr", "www.passwordle.fr", "www.supportin.it",
        "www.doctorican.it", "www.passwordle.it", "www.supportres.de",
        "www.doctorican.org", "www.passwordle.org", "www.supportres.es",
        "www.doctrical.com", "www.payrolltooling.com", "www.supportres.fr",
        "www.doctrical.de", "www.payrolltooling.net", "www.supportres.it",
        "www.doctrical.es", "www.prizeably.com", "www.supportres.org",
        "www.doctrical.fr", "www.prizeably.de", "www.techidal.com",
        "www.doctrical.it", "www.prizeably.es", "www.techidal.de",
        "www.doctrical.org", "www.prizeably.fr", "www.techidal.fr",
        "www.doctricant.com", "www.prizeably.it", "www.techidal.it",
        "www.doctrings.com", "www.prizeably.org", "www.techniel.de",
        "www.doctrings.de", "www.prizegiveaway.net", "www.techniel.es",
        "www.doctrings.es", "www.prizegives.com", "www.techniel.fr",
        "www.doctrings.fr", "www.prizemons.com", "www.techniel.it",
        "www.doctrings.it", "www.prizesforall.com", "www.templateau.com",
        "www.doctrings.org", "www.prizewel.com", "www.templatent.com",
        "www.exportants.com", "www.prizewings.com", "www.templatern.com",
        "www.exportants.de", "www.resetts.de", "www.windocyte.com",
        "www.exportants.es", "www.resetts.es",
        "www.exportants.fr", "www.resetts.fr"
    };
    
    private string _Url { get; set; }

    public ASTUrl(string URL)
    {
        _Url = URL;
    }

    public bool IsValid()
    {

        Uri uri;

        if (!Uri.TryCreate(_Url, UriKind.Absolute, out uri))
            return false;
        
        // Determine if host is in known hosts
        if (!_ValidURLs.Contains(uri.Host.ToLower()))
            return false;
        
        return true;
    }
}