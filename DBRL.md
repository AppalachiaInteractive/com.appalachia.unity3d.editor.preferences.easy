# Directory-Based Hierarchical Licensing

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