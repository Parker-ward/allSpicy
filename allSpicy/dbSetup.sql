CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    recipes(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        creatorId VARCHAR(255) NOT NULL,
        title VARCHAR(25) NOT NULL,
        instructions VARCHAR(255) NOT NULL,
        img VARCHAR(500) NOT NULL,
        category VARCHAR(50) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE recipes;

INSERT INTO
    recipes (
        title,
        category,
        instructions,
        `creatorId`,
        `img`
    )
VALUES (
        'cereal',
        'easy',
        'get bowl, mild and cereal, pour cereal into box, add it desired amount of milk, put away milk so it does not go bad, insert spoon into bowl... ENJOY! :)',
        '64056596b253fcef8a1f4da0',
        'https://images.unsplash.com/photo-1598170845058-32b9d6a5da37?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8Y2Fycm90c3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=800&q=60'
    );