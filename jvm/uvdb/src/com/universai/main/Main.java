package com.universai.main;

import java.sql.*;

public class Main {
    public static void main(String[] args) throws SQLException {
        var con = DriverManager.getConnection("jdbc:sqlserver://localhost;databaseName=UVDB;user=universai;password=solomatin11");
        var stmt = con.createStatement();
        var exq = stmt.executeQuery("SELECT * FROM dbo.People");
        while (exq.next()) {
            System.out.print(exq.getString("ID") + " ");
            System.out.println(exq.getString("Name"));
        }
        exq = stmt.executeQuery("INSERT INTO dbo.People VALUES (3, 'Matiashik')");
        exq = stmt.executeQuery("SELECT * FROM dbo.People");
        while (exq.next()) {
            System.out.print(exq.getString("ID") + " ");
            System.out.println(exq.getString("Name"));
        }
        exq = stmt.executeQuery()
    }
}
