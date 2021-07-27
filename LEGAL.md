# Legal Information

The most recent version of this document can be found [here](https://github.com/AppalachiaInteractive/com.appalachia.org/blob/main/legal/project-template/LEGAL.md).

This document will cover several topics:

- [Copyright](#copyright)
- [Trademarks and Servicemarks](#trademarks-and-servicemarks)
- [Licensing](#licensing)
- [Third Party Notices](#third-party-notices)
- [Directory-Based Hierarchical Licensing](#directory-based-hierarchical-licensing)

If you are the copyright, trademark, servicemark, or intellectual-property holder for something included in this project, and you do not feel that its use is adhering to your licensing terms, please immediately contact `admin (at) appalachiainteractive.com` so the issue can be addressed.

## Copyright

All contributions on behalf of `Appalachia Interactive`, or via `com.appalachia projects` are Copyright (c) `2021` `Appalachia Interactive`. All rights reserved.

All other contributions are Copyright (c) `2020` their respective contributors. All rights reserved.

## Trademarks and Servicemarks

### Appalachia Interactive

`Appalachia`, `Appa`, the `Appalachia Interactive` logo, the `Appalachia Interactive Mountain`, logo, and the `Appalachia Interactive Squirrel` logo are trademarks or registered trademarks of `Appalachia Interactive` or its affiliates in the U.S. and elsewhere.

### Unity Technologies

These materials are not sponsored by or affiliated with `Unity Technologies` or its affiliates. 
`Unity` and the `Unity` logo are trademarks or registered trademarks of `Unity Technologies` or its affiliates in the U.S. and elsewhere.

## Licensing

The license for this project is included in the [LICENSE.md](./LICENSE.md) file.

In some cases, a [NOTICE.md](./NOTICE.md) file will be included, further describing the specifics of project licensing.

It is possible that this project has preserved a previous license in either a subdirectory, such as [src/LICENSE.md](./src/LICENSE.md), or in a file 

## Third Party Notices

This project contains third-party software components governed by their own license and copyright notices.  

Please read further about [Directory-Based Hierarchical Licensing](#directory-based-hierarchical-licensing) to understand their interpretation and application.

In some cases, a [NOTICE.md](./NOTICE.md) file will be included, further describing the specifics of project licensing.

## Directory-Based Hierarchical Licensing

This project and its respective files and directories contains many license, copyright, trademark, and other legal notices (from here on referred to as `NOTICES`).

`NOTICES` can be identified by their file names.  They will contain one of the following case-insensitive identifiers:

- `LICENSE`
- `NOTICE`
- `LEGAL`
- `COPYRIGHT`
- `TRADEMARK`

Any casing combination of the previously listed identifiers can be considered valid as an identifier of `NOTICES`.  There may be other characters in the filename, surrounding the identifier.  Further, `NOTICES` may end with any file extension, including the lack of a file extension.

Therefore a system to interpret their application has been defined, namely `Directory-Based Recursive Licensing` (from here on referred to as `DBRL`).

- Occaisionally `NOTICES` are included as 'templates' or supplemental resources, and are not intended to apply to the contents of the project they occur within.  
  - `DBRL` does not consider or interpret as applicable `NOTICES` in:
    - Directories with names beginning with the character `.` (`period`).
    - Subdirectories of directories with names beginning with the character `.` (`period`).
    - Files with names beginning with the character `.` (`period`).
  - Examples of applicable `NOTICES`:
      - `directorya/subdirectory/LICENSE.md`
      - `LICENSE.txt`
      - `directorya/COPYRIGHT`
  - Examples of non-applicable NOTICES:
      - `.directorya/subdirectory/LICENSE.md`
      - `.LICENSE.txt`
      - `.directorya/COPYRIGHT`
    

- `NOTICES` that are applicable based on the previous scheme, shall be interpreted as applicable in the manner that follows:
  - `NOTICES` in a directory will apply to all files in that directory, unless their content states otherwise.
  - `NOTICES` in a directory will apply to all directories in that directory, unless their content states otherwise.  This application will continue recursively, *EXCEPT*
    - if any subdirectory introduces `NEW` `NOTICES`.  In such a case:
      - the `NEW` `NOTICES` shall apply in the manner specified above, for files, directories, and subdirectories recursively in the aforementioned subdirectory.
      - the `OLD` `NOTICES` shall no longer apply in the manner specified above, for files, directories, and subdirectories recursively in the aforementioned subdirectory. 

Therefore, including `NOTICES` at the root of a project covers all files and directories in the project, except those with other specified `NOTICES`.
