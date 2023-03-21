CREATE TABLE IF NOT EXISTS "User" (
  "Id" SERIAL NOT NULL,
  "Name" VARCHAR(250) NOT NULL,
  PRIMARY KEY ("Id")
);

CREATE TABLE IF NOT EXISTS "Instruction" (
  "Id" SERIAL NOT NULL,
  "UserId" INT NOT NULL,
  "DayOfMonth" INT NOT NULL,
  "InstructionAmount" DECIMAL NOT NULL,
  "IsActive" BOOLEAN NOT NULL,
  PRIMARY KEY ("Id")
);

CREATE TABLE IF NOT EXISTS "InstructionNotification" (
  "Id" SERIAL NOT NULL,
  "InstructionId" INT NOT NULL,
  "Type" INT NOT NULL,
  "IsActive" BOOLEAN NOT NULL,
  PRIMARY KEY ("Id")
);

INSERT INTO "User" ("Name") VALUES ('Yakup Önal');