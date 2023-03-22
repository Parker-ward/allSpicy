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
        imgUrl VARCHAR(500) NOT NULL,
        category VARCHAR(50) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

INSERT INTO
    recipes (
        title,
        category,
        instructions,
        `imgUrl`
    );
VALUES (
        'hotdogs',
        'easyMeals',
        'open package, place in microwave, cook for 30 seconds',
        'https://media.istockphoto.com/id/1408284874/photo/delicious-hot-dog-in-male-hand-on-white.jpg?b=1&s=170667a&w=0&k=20&c=CZvMskynC6lqoVhtiVeE4qvBI3mwBshdV6lsovFsVPA='
    );