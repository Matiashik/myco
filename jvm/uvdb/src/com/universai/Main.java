package com.universai.main;

import java.sql.*;
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) throws SQLException {
        var con = DriverManager.getConnection("jdbc:sqlserver://localhost;databaseName=UVDB;user=universai;password=solomatin11");
        var stmt = con.createStatement();
        var exq  = stmt.executeQuery("select * from phones where TECH = 'XIAOMI'");
        var a = new ArrayList<Integer>();
        while(exq.next()) {
            a.add(exq.getInt(1));
        }
        System.out.println(a.size());
    }
}