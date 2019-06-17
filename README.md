# EntityZip
A simple lib to help us to zip information and allow users to download data. 

```C#
EntityZipConverter zip = new EntityZipConverter();
zip.ConvertEntityToCSV(person, "Person");
zip.ConvertListToCSV<Address>(person.Addresses, "Adresses");
File.WriteAllBytes("MyData.zip", zip.ConvertToZipBytes());
```
