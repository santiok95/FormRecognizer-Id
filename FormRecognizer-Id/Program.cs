using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;

//use your `key` and `endpoint` environment variables to create your `AzureKeyCredential` and `DocumentAnalysisClient` instances
string key = "3cefc52d84204f3dbc295d3a3cc9ed7f";
string endpoint = "https://demorecognizer15.cognitiveservices.azure.com/";
AzureKeyCredential credential = new AzureKeyCredential(key);
DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), credential);

// sample document document

Uri idDocumentUri = new Uri("https://raw.githubusercontent.com/Azure-Samples/cognitive-services-REST-api-samples/master/curl/form-recognizer/rest-api/identity_documents.png");

AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-idDocument", idDocumentUri);

AnalyzeResult identityDocuments = operation.Value;

AnalyzedDocument identityDocument = identityDocuments.Documents.Single();

if (identityDocument.Fields.TryGetValue("Address", out DocumentField addressField))
{
    if (addressField.FieldType == DocumentFieldType.String)
    {
        string address = addressField.Value.AsString();
        Console.WriteLine($"Address: '{address}', with confidence {addressField.Confidence}");
    }
}

if (identityDocument.Fields.TryGetValue("CountryRegion", out DocumentField countryRegionField))
{
    if (countryRegionField.FieldType == DocumentFieldType.CountryRegion)
    {
        string countryRegion = countryRegionField.Value.AsCountryRegion();
        Console.WriteLine($"CountryRegion: '{countryRegion}', with confidence {countryRegionField.Confidence}");
    }
}

if (identityDocument.Fields.TryGetValue("DateOfBirth", out DocumentField dateOfBirthField))
{
    if (dateOfBirthField.FieldType == DocumentFieldType.Date)
    {
        DateTimeOffset dateOfBirth = dateOfBirthField.Value.AsDate();
        Console.WriteLine($"Date Of Birth: '{dateOfBirth}', with confidence {dateOfBirthField.Confidence}");
    }
}

if (identityDocument.Fields.TryGetValue("DateOfExpiration", out DocumentField dateOfExpirationField))
{
    if (dateOfExpirationField.FieldType == DocumentFieldType.Date)
    {
        DateTimeOffset dateOfExpiration = dateOfExpirationField.Value.AsDate();
        Console.WriteLine($"Date Of Expiration: '{dateOfExpiration}', with confidence {dateOfExpirationField.Confidence}");
    }
}

if (identityDocument.Fields.TryGetValue("DocumentNumber", out DocumentField documentNumberField))
{
    if (documentNumberField.FieldType == DocumentFieldType.String)
    {
        string documentNumber = documentNumberField.Value.AsString();
        Console.WriteLine($"Document Number: '{documentNumber}', with confidence {documentNumberField.Confidence}");
    }
}

if (identityDocument.Fields.TryGetValue("FirstName", out DocumentField firstNameField))
{
    if (firstNameField.FieldType == DocumentFieldType.String)
    {
        string firstName = firstNameField.Value.AsString();
        Console.WriteLine($"First Name: '{firstName}', with confidence {firstNameField.Confidence}");
    }
}

if (identityDocument.Fields.TryGetValue("LastName", out DocumentField lastNameField))
{
    if (lastNameField.FieldType == DocumentFieldType.String)
    {
        string lastName = lastNameField.Value.AsString();
        Console.WriteLine($"Last Name: '{lastName}', with confidence {lastNameField.Confidence}");
    }
}

if (identityDocument.Fields.TryGetValue("Region", out DocumentField regionfield))
{
    if (regionfield.FieldType == DocumentFieldType.String)
    {
        string region = regionfield.Value.AsString();
        Console.WriteLine($"Region: '{region}', with confidence {regionfield.Confidence}");
    }
}

if (identityDocument.Fields.TryGetValue("Sex", out DocumentField sexfield))
{
    if (sexfield.FieldType == DocumentFieldType.String)
    {
        string sex = sexfield.Value.AsString();
        Console.WriteLine($"Sex: '{sex}', with confidence {sexfield.Confidence}");
    }
}