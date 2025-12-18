package letsgetorganizedlogic;
import java.io.IOException;
import java.nio.file.*;
import java.nio.file.attribute.BasicFileAttributes;

public class DeterminePath {

    public static Path normalizePathString(String raw) {
        if (raw == null) throw new IllegalArgumentException("path is null");

        String s = raw.trim();

        if (s.matches("^[A-Za-z]:$")) {
            s = s + "\\";
        }

        s = s.replace('/', '\\');

        return Path.of(s).normalize();
    }

    public static void walkDirectory(Path root) throws IOException {
        if (root == null) throw new IllegalArgumentException("root is null");

        Files.walkFileTree(root, new SimpleFileVisitor<>() {

            @Override
            public FileVisitResult preVisitDirectory(Path dir, BasicFileAttributes attrs) {
                System.out.println("DIR  " + dir);
                return FileVisitResult.CONTINUE;
            }

            @Override
            public FileVisitResult visitFile(Path file, BasicFileAttributes attrs) {
                System.out.println("FILE " + file);
                return FileVisitResult.CONTINUE;
            }

            @Override
            public FileVisitResult visitFileFailed(Path file, IOException exc) {
                System.err.println("SKIP " + file + " (" + exc.getMessage() + ")");
                return FileVisitResult.CONTINUE;
            }
        });
    }

    public static CreateDirList peekDirectory(Path root) throws IOException {
        if (root == null) throw new IllegalArgumentException("Root is null");
        if(!Files.isDirectory(root)) throw new IllegalArgumentException("Path is not a directory: " + root);

        CreateDirList directoryList = new CreateDirList();

        try(DirectoryStream<Path> stream = Files.newDirectoryStream(root)) {
            for(Path entry : stream) {
                if(Files.isDirectory(entry)) {
                    directoryList.addFolderToList(entry);
                } else {
                    directoryList.addFileToList(entry);
                }
            }   
        }
        return directoryList;
    }
}
