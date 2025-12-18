package letsgetorganizedlogic;

import java.nio.file.Path;

public class App {

    public static void main(String[] args) {
        if (args.length < 2) {
            System.err.println("usage: <path>");
            System.exit(1);
        }

        String mode = args[0];
        String pathArg = args[1];

        try {
            if (mode.equalsIgnoreCase("full")) {
                Path rootOrFolder = DeterminePath.normalizePathString(pathArg);
                DeterminePath.walkDirectory(rootOrFolder);
            }
            else if(mode.equalsIgnoreCase("partial")){
                Path rootOrFolder = DeterminePath.normalizePathString(pathArg);
                CreateDirList folderList = DeterminePath.peekDirectory(rootOrFolder);

                for(Path line : folderList.getDirectoryFolderList()){
                    System.out.println(line);
                }

                for(Path line : folderList.getDirectoryFileList()){
                    System.out.println(line);
                }
            } else {
                System.err.println("Unknown Mode: " + mode);
                System.exit(1);
            }
        } catch (Exception error) {
            System.err.println("error: " + error.getMessage());
            error.printStackTrace(System.err);
            System.exit(1);
        }
    }
}
