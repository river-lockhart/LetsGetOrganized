package letsgetorganizedlogic;
import java.nio.file.Path;
import java.util.ArrayList;

public class CreateDirList {
 
    private final ArrayList<Path> directoryFolderList = new ArrayList<>();
    private final ArrayList<Path> directoryFileList = new ArrayList<>();

    public void addFolderToList(Path folderPath) {
        directoryFolderList.add(folderPath);
    }

    public void addFileToList(Path filePath) {
        directoryFileList.add(filePath);
    }

    public ArrayList<Path> getDirectoryFolderList() {
        return directoryFolderList;
    }

    public ArrayList<Path> getDirectoryFileList() {
        return directoryFileList;
    }
}
