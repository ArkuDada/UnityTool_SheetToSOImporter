# UnityTool_SheetToSOImporter

## Overview
UnityTool_SheetToSOImporter is a proof-of-concept (POC) tool designed to streamline the process of importing data from Google Sheets (or similar sources) into Unity. The tool fetches JSON-formatted data from a specified URL and dynamically converts it into Unity `ScriptableObject` assets. This allows developers to manage and utilize structured data (e.g., game stats, configurations) directly within the Unity Editor.

### Key Features:
- Fetches JSON data from a remote URL.
- Dynamically parses the JSON into predefined classes.
- Generates or updates `ScriptableObject` assets under the `Resources` folder.
- Supports multiple data classes through a dropdown selector.

## Current Limitations
While the tool is functional, it has some limitations that affect its flexibility and usability:

1. **JSON Parsing Flexibility**:
    - The tool relies on Unity's `JsonUtility`, which does not natively support JSON arrays or complex structures. This requires wrapping arrays in a container class or using workarounds.
    - Mitigation: Consider using `Newtonsoft.Json` for more robust JSON parsing, as it supports arrays and complex structures directly.

2. **Class Discovery**:
    - The tool dynamically discovers classes in the `Editor.SheetTool` namespace, which may not be flexible for projects with classes in other namespaces.
    - Mitigation: Allow users to specify namespaces or manually register classes to improve flexibility.

3. **Error Handling**:
    - The tool lacks comprehensive error handling for scenarios like invalid JSON, network failures, or missing class definitions.
    - Mitigation: Add detailed error messages and fallback mechanisms to improve user experience.

4. **Asset Management**:
    - Assets are always created or updated in the `Resources` folder, which may not suit all project structures.
    - Mitigation: Allow users to configure the asset output path dynamically.

## Links
- **Sample Google Sheet**: [Google Sheet Example](https://docs.google.com/spreadsheets/d/1ZRwI8qC9ys3IDbUTwOaZEza7AeRtIvdqoqCI5XVK05Q/edit?usp=sharing)
- **Google Apps Script (JSON Endpoint)**: [JSON Endpoint](https://script.google.com/macros/s/AKfycbxO5E-gJJGV2nc39mUbeZS_-qoZsCm833Dd_c2c_UpHOIj7gEAnRA4yZGa0ao_AxgA/exec)

## Conclusion
UnityTool_SheetToSOImporter is a promising tool for importing structured data into Unity, but addressing its current limitations will make it more robust and adaptable for diverse use cases. By incorporating more flexible JSON parsing, customizable settings, and improved error handling, the tool can become a valuable asset for Unity developers.