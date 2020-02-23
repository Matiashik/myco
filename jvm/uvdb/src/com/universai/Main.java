package com.universai;

import java.sql.*;

public class Main {
    public static void main(String[] args) throws SQLException {
        var con = DriverManager.getConnection("jdbc:sqlserver://localhost;databaseName=UVDB;user=SA;" +
                "password=Solomatin11;");
        var stmt = con.createStatement();
        var res = stmt.executeQuery("select * from List");
        while(res.next()) {
            System.out.println(res.getInt(1) + " " + res.getString(2) + " " + res.getString(3));
        }
    }
    public static void Insert(Statement stmt) throws SQLException {
        var langs = new String[]{"F#", "C#", "GO", "JS", "C++", "JAVA"};
        for(int i = 1; i <= 1000; i++) {
            var str = "insert into List values(";
            String lang, auth;
            try{lang = langs[(int)(Math.random()*10)]; auth = "MATIASH";}
            catch(Exception ex){lang = "PYTHON"; auth = "PIDOR";}
            var cmd = "insert into List values(" + i + ", \'" + lang + "\', \'" + auth + "\');";
            stmt.execute(cmd);
        }
    }
}
