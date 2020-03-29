# EntityZip
Example: 

```C#
EntityZipConverter zip = new EntityZipConverter();
zip.ConvertEntityToCSV(person, "Person");
zip.ConvertListToCSV<Address>(person.Addresses, "Adresses");
File.WriteAllBytes("MyData.zip", zip.ConvertToZipBytes());
```
