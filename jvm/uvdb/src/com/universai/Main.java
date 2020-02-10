package com.universai;

import com.mongodb.MongoClient;
import org.bson.Document;

import java.util.ArrayList;
import java.util.Random;

public class Main {
    public static void main(String[] args) {
        var mgcl = new MongoClient("localhost");
        var mgdb = mgcl.getDatabase("uvdb");
        var col = mgdb.getCollection("List");
        var lang = new String[] {"GO", "JAVA", "C#", "F#", "C++", "JS"};
        var docs = new ArrayList<Document>();
        for(int i = 0; i < 1000; i++) {
            try {
                docs.add(new Document("lang", lang[(int)(Math.random() * 10)])
                        .append("progger", "Matiash")
                        .append("i", i)
                );
            } catch (Exception ex) {
                docs.add(new Document("lang", "Python")
                        .append("progger", "Pidaras")
                        .append("i", i)
                );
            }
        }
        col.insertMany(docs);
    }
}
