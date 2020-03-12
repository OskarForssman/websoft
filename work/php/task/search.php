<!doctype html>
<html lang="en">
<?php include 'header.php';?>
<head>
    <meta charset="utf-8">
    <title>Search!</title>
    <link rel="stylesheet" type="text/css" href="Style/Style.css">
</head>
<?php
/**
 * A page controller
 */
require "db/config.php";
require "src/functions.php";

// Get incoming values
$search = $_GET["search"] ?? null;
$like = "%$search%";
//var_dump($_GET);

if ($search) {
    // Connect to the database
    $db = connectDatabase($dsn);

    // Prepare and execute the SQL statement
    $sql = <<<EOD
SELECT
    *
FROM tech
WHERE
    id = ?
    OR type LIKE ?
    OR price LIKE ?
;
EOD;
    $stmt = $db->prepare($sql);
    $stmt->execute([$search, $like, $like]);

    // Get the results as an array with column names as array keys
    $res = $stmt->fetchAll();
}




?><h1>Search the database</h1>

<form>
    <p>
        <label>Search: 
            <input type="text" name="search" value="<?= $search ?>">
        </label>
    </p>
</form>

<?php if ($search) : ?>
    <table>
        <tr>
            <th>Id</th>
            <th>GameName</th>
            <th>Price</th>

        </tr>

    <?php foreach ($res as $row) : ?>
        <tr>
            <td><?= $row["id"] ?></td>
            <td><?= $row["type"] ?></td>
            <td><?= $row["price"] ?></td>
        </tr>
    <?php endforeach; ?>

    </table>
<?php endif; ?>



<style>

header nav a:hover{
        color: red;
    }
    header nav a{
        color: white;
    }
    html {
      background-color: black;
    }
    body{
        background-color: black;
        color: white;
    }
    </style>
