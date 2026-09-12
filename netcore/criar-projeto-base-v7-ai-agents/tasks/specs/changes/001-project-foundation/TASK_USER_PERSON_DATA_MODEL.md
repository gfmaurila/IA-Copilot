# TASK — User & Person Data Model

## 1. Objective

Create the relational data model for user registration, personal data, authentication, authorization, preferences, security, auditing, and organizational structure.

The database naming convention must follow **English names** using **UPPER_SNAKE_CASE** for tables and fields.

Example:

```text
USER_ACCOUNT
PERSON
PERSON_DOCUMENT
CREATED_AT
UPDATED_AT
```

The model separates **PERSON** from **USER_ACCOUNT**:

- `PERSON` stores personal information.
- `USER_ACCOUNT` stores authentication, access, and security information.
- A person may exist without having system access.
- A user account is linked to a person through `PERSON_ID`.

---

# 2. General Conventions

## 2.1 Primary Keys

All tables must have an `ID` field as the primary key.

Recommended type:

```text
UUID
```

or, depending on the adopted database strategy:

```text
BIGINT
```

The same strategy must be used consistently across the entire database.

---

## 2.2 Foreign Keys

Foreign keys must use the referenced entity name followed by `_ID`.

Examples:

```text
PERSON_ID
USER_ID
ROLE_ID
ORGANIZATION_ID
RESOURCE_ID
```

---

## 2.3 Audit Fields

Where defined in the model, use:

```text
CREATED_AT
UPDATED_AT
DELETED_AT
```

`DELETED_AT` represents logical deletion / soft delete.

A record with `DELETED_AT IS NOT NULL` must normally be considered deleted or inactive for application queries.

---

## 2.4 Status

Entities that contain `STATUS` must use this field to control the record lifecycle.

Possible values may include:

```text
ACTIVE
INACTIVE
BLOCKED
PENDING
DELETED
```

The exact accepted values should be defined in the application/domain layer.

---

# 3. Tables

---

# 3.1 ORGANIZATION

## Purpose

Represents a company, tenant, customer organization, institution, or business unit that owns groups and may define its own access roles.

This table can be used as the main organizational scope for a multi-tenant application.

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

Uniquely identifies the organization.

### CODE

```text
CODE : VARCHAR(50)
```

Unique business code used to identify the organization.

Must be unique.

Example:

```text
ACME
CUSTOMER_001
ORG_BR_01
```

### LEGAL_NAME

```text
LEGAL_NAME : VARCHAR(200)
```

Official/legal name of the organization.

### TRADE_NAME

```text
TRADE_NAME : VARCHAR(200)
```

Commercial or trading name used by the organization.

### TAX_ID

```text
TAX_ID : VARCHAR(30)
```

Tax or fiscal identifier.

Must be unique.

For a Brazilian organization, this may contain a CNPJ.

### EMAIL

```text
EMAIL : VARCHAR(180)
```

Main contact email address for the organization.

### PHONE

```text
PHONE : VARCHAR(30)
```

Main contact telephone number.

### WEBSITE

```text
WEBSITE : VARCHAR(180) NULL
```

Organization website.

Optional.

### TIME_ZONE

```text
TIME_ZONE : VARCHAR(60)
```

Default time zone used by the organization.

Example:

```text
America/Sao_Paulo
```

### LOCALE

```text
LOCALE : VARCHAR(10)
```

Default locale/language-region setting.

Example:

```text
pt-BR
en-US
```

### STATUS

```text
STATUS : VARCHAR(30)
```

Current organization status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Date/time when the record was created.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Date/time of the most recent update.

### DELETED_AT

```text
DELETED_AT : DATETIME NULL
```

Date/time of logical deletion.

Null means that the organization has not been soft-deleted.

---

# 3.2 USER_GROUP

## Purpose

Represents a group of users inside an organization.

Groups can be used to organize users by department, team, branch, project, unit, or other logical segmentation.

Relationship:

```text
ORGANIZATION 1 --- N USER_GROUP
```

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### ORGANIZATION_ID

```text
ORGANIZATION_ID : UUID/BIGINT
```

Foreign key to `ORGANIZATION.ID`.

Defines which organization owns the group.

### CODE

```text
CODE : VARCHAR(50)
```

Unique group code.

### NAME

```text
NAME : VARCHAR(120)
```

Group name.

Examples:

```text
Administrators
Support
Finance
Operations
```

### DESCRIPTION

```text
DESCRIPTION : VARCHAR(255)
```

Description of the group and its purpose.

### STATUS

```text
STATUS : VARCHAR(30)
```

Current group status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

### DELETED_AT

```text
DELETED_AT : DATETIME NULL
```

Soft-delete date/time.

---

# 3.3 PERSON

## Purpose

Stores personal information about an individual.

This table must not contain authentication credentials.

Authentication and security data belong to `USER_ACCOUNT`.

A person may exist in the application without having a user account.

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### FIRST_NAME

```text
FIRST_NAME : VARCHAR(100)
```

Person's first name.

### MIDDLE_NAME

```text
MIDDLE_NAME : VARCHAR(100) NULL
```

Middle name.

Optional.

### LAST_NAME

```text
LAST_NAME : VARCHAR(150)
```

Last name / surname.

### PREFERRED_NAME

```text
PREFERRED_NAME : VARCHAR(150) NULL
```

Preferred, social, display, or commonly used name.

Optional.

### BIRTH_DATE

```text
BIRTH_DATE : DATE NULL
```

Date of birth.

Optional.

### GENDER

```text
GENDER : VARCHAR(30) NULL
```

Gender information when applicable to the business domain.

Optional.

### MARITAL_STATUS

```text
MARITAL_STATUS : VARCHAR(30) NULL
```

Marital status.

Optional.

### NATIONALITY

```text
NATIONALITY : VARCHAR(80) NULL
```

Nationality.

Optional.

### AVATAR_URL

```text
AVATAR_URL : VARCHAR(500) NULL
```

URL or storage reference for the person's profile image/avatar.

### STATUS

```text
STATUS : VARCHAR(30)
```

Current person record status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

### DELETED_AT

```text
DELETED_AT : DATETIME NULL
```

Soft-delete date/time.

---

# 3.4 USER_ACCOUNT

## Purpose

Stores login, authentication, account status, and security-related data.

`USER_ACCOUNT` must not be used as the main storage for personal profile information.

Personal data belongs to `PERSON`.

Relationship:

```text
PERSON 1 --- 0..1 USER_ACCOUNT
USER_GROUP 1 --- N USER_ACCOUNT
```

`PERSON_ID` is unique in the current model, allowing one user account per person.

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### GROUP_ID

```text
GROUP_ID : UUID/BIGINT NULL
```

Foreign key to `USER_GROUP.ID`.

Defines the main group associated with the user.

Optional.

### PERSON_ID

```text
PERSON_ID : UUID/BIGINT
```

Foreign key to `PERSON.ID`.

Must be unique according to the current model.

Associates the account with the personal profile.

### USERNAME

```text
USERNAME : VARCHAR(100)
```

Login username.

Must be unique.

### EMAIL

```text
EMAIL : VARCHAR(180)
```

Email used by the account.

Must be unique.

### PASSWORD_HASH

```text
PASSWORD_HASH : VARCHAR(255)
```

Stores the password hash.

The plain-text password must never be stored.

### PASSWORD_CHANGED_AT

```text
PASSWORD_CHANGED_AT : DATETIME NULL
```

Date/time when the password was last changed.

### EMAIL_VERIFIED_AT

```text
EMAIL_VERIFIED_AT : DATETIME NULL
```

Date/time when the account email was verified.

Null means that email verification has not been completed.

### PHONE_VERIFIED_AT

```text
PHONE_VERIFIED_AT : DATETIME NULL
```

Date/time when the associated phone was verified.

### LAST_LOGIN_AT

```text
LAST_LOGIN_AT : DATETIME NULL
```

Date/time of the most recent successful login.

### LAST_LOGIN_IP

```text
LAST_LOGIN_IP : VARCHAR(45) NULL
```

IP address from the most recent successful login.

Length 45 supports IPv4 and IPv6 text representations.

### FAILED_LOGIN_ATTEMPTS

```text
FAILED_LOGIN_ATTEMPTS : INT
```

Number of consecutive or currently accumulated failed login attempts.

Can be used as part of the account lockout policy.

### LOCKED_UNTIL

```text
LOCKED_UNTIL : DATETIME NULL
```

Date/time until which the user account remains locked.

Null indicates no temporary lock defined by this field.

### MUST_CHANGE_PASSWORD

```text
MUST_CHANGE_PASSWORD : BOOLEAN
```

Indicates whether the user must change the password at the next valid login.

### TWO_FACTOR_ENABLED

```text
TWO_FACTOR_ENABLED : BOOLEAN
```

Indicates whether two-factor authentication is enabled.

### STATUS

```text
STATUS : VARCHAR(30)
```

Account status.

Typical business states may include:

```text
ACTIVE
INACTIVE
PENDING
BLOCKED
```

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Account creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last account update date/time.

### DELETED_AT

```text
DELETED_AT : DATETIME NULL
```

Soft-delete date/time.

---

# 3.5 PERSON_DOCUMENT

## Purpose

Stores documents associated with a person.

A person may have multiple documents.

Relationship:

```text
PERSON 1 --- N PERSON_DOCUMENT
```

Examples of document types include:

```text
CPF
CNPJ
RG
CNH
PASSPORT
```

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### PERSON_ID

```text
PERSON_ID : UUID/BIGINT
```

Foreign key to `PERSON.ID`.

### DOCUMENT_TYPE

```text
DOCUMENT_TYPE : VARCHAR(30)
```

Type of document.

### DOCUMENT_NUMBER

```text
DOCUMENT_NUMBER : VARCHAR(50)
```

Document number or identifier.

### ISSUER

```text
ISSUER : VARCHAR(80) NULL
```

Issuing authority.

### ISSUING_STATE

```text
ISSUING_STATE : VARCHAR(50) NULL
```

State/region where the document was issued.

### ISSUE_DATE

```text
ISSUE_DATE : DATE NULL
```

Document issue date.

### EXPIRATION_DATE

```text
EXPIRATION_DATE : DATE NULL
```

Document expiration date.

### COUNTRY_CODE

```text
COUNTRY_CODE : CHAR(2)
```

Two-character country code associated with the document.

### IS_PRIMARY

```text
IS_PRIMARY : BOOLEAN
```

Indicates whether this is the person's primary document record.

### STATUS

```text
STATUS : VARCHAR(30)
```

Document record status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

### DELETED_AT

```text
DELETED_AT : DATETIME NULL
```

Soft-delete date/time.

---

# 3.6 CONTACT_TYPE

## Purpose

Stores the catalog of supported contact channels/types.

This avoids persisting free-form contact type names directly in `PERSON_CONTACT` and allows validation/configuration per contact channel.

Relationship:

```text
CONTACT_TYPE 1 --- N PERSON_CONTACT
```

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### CODE

```text
CODE : VARCHAR(30)
```

Unique stable code used by the application.

Initial values:

```text
PHONE
MOBILE
EMAIL
WHATSAPP
TELEGRAM
OTHER
```

### NAME

```text
NAME : VARCHAR(80)
```

Human-readable contact type name.

### DESCRIPTION

```text
DESCRIPTION : VARCHAR(255) NULL
```

Optional explanation of the contact type.

### VALIDATION_PATTERN

```text
VALIDATION_PATTERN : VARCHAR(500) NULL
```

Optional regular expression or validation rule metadata used to validate `CONTACT_VALUE`.

### MAX_LENGTH

```text
MAX_LENGTH : INT NULL
```

Optional maximum length accepted for values of this contact type.

### IS_SYSTEM

```text
IS_SYSTEM : BOOLEAN
```

Indicates whether this is a protected system-defined contact type.

### STATUS

```text
STATUS : VARCHAR(30)
```

Contact type status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

### DELETED_AT

```text
DELETED_AT : DATETIME NULL
```

Soft-delete date/time.

---

# 3.7 PERSON_CONTACT

## Purpose

Stores contact information associated with a person.

This design allows one person to have multiple contact records instead of fixed phone/email columns on `PERSON`.

Relationship:

```text
PERSON 1 --- N PERSON_CONTACT

CONTACT_TYPE 1 --- N PERSON_CONTACT
```

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### PERSON_ID

```text
PERSON_ID : UUID/BIGINT
```

Foreign key to `PERSON.ID`.

### CONTACT_TYPE_ID

```text
CONTACT_TYPE_ID : UUID/BIGINT
```

Foreign key to `CONTACT_TYPE.ID`.

Defines the channel/type of the contact.

### CONTACT_VALUE

```text
CONTACT_VALUE : VARCHAR(180)
```

Actual contact information.

Examples:

```text
john@email.com
+55 51 99999-9999
```

### LABEL

```text
LABEL : VARCHAR(50) NULL
```

Optional descriptive label.

Examples:

```text
PERSONAL
WORK
HOME
EMERGENCY
```

### IS_PRIMARY

```text
IS_PRIMARY : BOOLEAN
```

Indicates whether this is the primary contact of its type or for the person.

### IS_VERIFIED

```text
IS_VERIFIED : BOOLEAN
```

Indicates whether the contact information has been verified.

### VERIFIED_AT

```text
VERIFIED_AT : DATETIME NULL
```

Date/time when the contact was verified.

### STATUS

```text
STATUS : VARCHAR(30)
```

Contact record status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

### DELETED_AT

```text
DELETED_AT : DATETIME NULL
```

Soft-delete date/time.

---

# 3.8 ADDRESS

## Purpose

Stores addresses associated with a person.

A person may have multiple addresses.

Relationship:

```text
PERSON 1 --- N ADDRESS
```

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### PERSON_ID

```text
PERSON_ID : UUID/BIGINT
```

Foreign key to `PERSON.ID`.

### ADDRESS_TYPE

```text
ADDRESS_TYPE : VARCHAR(30)
```

Type/category of address.

Possible values:

```text
HOME
WORK
BILLING
SHIPPING
OTHER
```

### POSTAL_CODE

```text
POSTAL_CODE : VARCHAR(20)
```

Postal/ZIP code.

### STREET

```text
STREET : VARCHAR(180)
```

Street name.

### NUMBER

```text
NUMBER : VARCHAR(30) NULL
```

Street/building number.

Optional because some addresses may have no numeric number.

### COMPLEMENT

```text
COMPLEMENT : VARCHAR(120) NULL
```

Additional address information.

Examples:

```text
Apartment 101
Block B
Room 203
```

### DISTRICT

```text
DISTRICT : VARCHAR(120) NULL
```

District/neighborhood.

### CITY

```text
CITY : VARCHAR(120)
```

City.

### STATE

```text
STATE : VARCHAR(80)
```

State/province/region.

### COUNTRY_CODE

```text
COUNTRY_CODE : CHAR(2)
```

Two-character country code.

### LATITUDE

```text
LATITUDE : DECIMAL(10,7) NULL
```

Latitude coordinate.

Optional.

### LONGITUDE

```text
LONGITUDE : DECIMAL(10,7) NULL
```

Longitude coordinate.

Optional.

### IS_PRIMARY

```text
IS_PRIMARY : BOOLEAN
```

Indicates whether this is the person's primary address.

### STATUS

```text
STATUS : VARCHAR(30)
```

Address record status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

### DELETED_AT

```text
DELETED_AT : DATETIME NULL
```

Soft-delete date/time.

---

# 3.9 ROLE

## Purpose

Represents an access profile / role.

Examples mentioned in the model include:

```text
ADMIN
CUSTOMER
OPERATOR
```

Custom roles may also be created.

A role groups multiple permissions and can be associated with multiple users.

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### ORGANIZATION_ID

```text
ORGANIZATION_ID : UUID/BIGINT NULL
```

Foreign key to `ORGANIZATION.ID`.

When present, the role belongs to a specific organization.

Null can be used for a system/global role.

### CODE

```text
CODE : VARCHAR(50)
```

Unique role code.

### NAME

```text
NAME : VARCHAR(80)
```

Human-readable role name.

### DESCRIPTION

```text
DESCRIPTION : VARCHAR(255) NULL
```

Role description.

### IS_SYSTEM

```text
IS_SYSTEM : BOOLEAN
```

Indicates whether the role is controlled by the application/system.

This can be used to prevent protected roles from being removed or arbitrarily modified.

### STATUS

```text
STATUS : VARCHAR(30)
```

Role status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

### DELETED_AT

```text
DELETED_AT : DATETIME NULL
```

Soft-delete date/time.

---

# 3.10 RESOURCE

## Purpose

Represents a protected application resource, screen, route, menu item, module, or feature.

`RESOURCE` is used together with `PERMISSION` to define authorization rules.

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### CODE

```text
CODE : VARCHAR(100)
```

Unique resource code.

### NAME

```text
NAME : VARCHAR(120)
```

Human-readable resource name.

### ROUTE

```text
ROUTE : VARCHAR(180) NULL
```

Associated application or frontend route.

Example:

```text
/admin/users
/admin/roles
```

### MODULE

```text
MODULE : VARCHAR(100)
```

Application module to which the resource belongs.

Examples:

```text
USER_MANAGEMENT
SECURITY
ADMINISTRATION
```

### DISPLAY_ORDER

```text
DISPLAY_ORDER : INT
```

Ordering value for menu or resource presentation.

### ICON

```text
ICON : VARCHAR(100) NULL
```

Optional icon identifier for UI rendering.

### PARENT_RESOURCE_ID

```text
PARENT_RESOURCE_ID : UUID/BIGINT NULL
```

Self-reference to `RESOURCE.ID`.

Allows creation of hierarchical menus/resources.

Example:

```text
Administration
    Users
    Roles
    Permissions
```

### STATUS

```text
STATUS : VARCHAR(30)
```

Resource status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

---

# 3.11 PERMISSION

## Purpose

Represents an action that can be executed against a protected application resource.

The current model notes that permissions represent operations such as:

```text
READ
WRITE
UPDATE
DELETE
```

Relationship:

```text
RESOURCE 1 --- N PERMISSION
```

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### RESOURCE_ID

```text
RESOURCE_ID : UUID/BIGINT
```

Foreign key to `RESOURCE.ID`.

Defines the protected resource related to the permission.

### CODE

```text
CODE : VARCHAR(100)
```

Unique permission code.

Example:

```text
USER_READ
USER_CREATE
USER_UPDATE
USER_DELETE
```

### ACTION

```text
ACTION : VARCHAR(30)
```

Action allowed by the permission.

### DESCRIPTION

```text
DESCRIPTION : VARCHAR(255) NULL
```

Human-readable description of the permission.

### STATUS

```text
STATUS : VARCHAR(30)
```

Permission status.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

---

# 3.12 USER_ROLE

## Purpose

Associative table connecting users to roles.

Implements the many-to-many relationship:

```text
USER_ACCOUNT N --- N ROLE
```

It also allows role assignment metadata such as assignment date, assigning user, and expiration.

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### USER_ID

```text
USER_ID : UUID/BIGINT
```

Foreign key to `USER_ACCOUNT.ID`.

### ROLE_ID

```text
ROLE_ID : UUID/BIGINT
```

Foreign key to `ROLE.ID`.

### ASSIGNED_AT

```text
ASSIGNED_AT : DATETIME
```

Date/time when the role was assigned.

### ASSIGNED_BY

```text
ASSIGNED_BY : UUID/BIGINT NULL
```

Identifier of the user responsible for the assignment.

### EXPIRES_AT

```text
EXPIRES_AT : DATETIME NULL
```

Optional role expiration date/time.

Allows temporary access profiles.

---

# 3.13 ROLE_PERMISSION

## Purpose

Associative table connecting roles to permissions.

Implements:

```text
ROLE N --- N PERMISSION
```

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### ROLE_ID

```text
ROLE_ID : UUID/BIGINT
```

Foreign key to `ROLE.ID`.

### PERMISSION_ID

```text
PERMISSION_ID : UUID/BIGINT
```

Foreign key to `PERMISSION.ID`.

### IS_ALLOWED

```text
IS_ALLOWED : BOOLEAN
```

Defines whether the permission is allowed for the role.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Date/time when the role-permission association was created.

---

# 3.14 REFRESH_TOKEN

## Purpose

Stores refresh tokens used by the authentication mechanism.

The model stores a token hash rather than the raw token.

Relationship:

```text
USER_ACCOUNT 1 --- N REFRESH_TOKEN
```

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### USER_ID

```text
USER_ID : UUID/BIGINT
```

Foreign key to `USER_ACCOUNT.ID`.

### TOKEN_HASH

```text
TOKEN_HASH : VARCHAR(255)
```

Hash of the refresh token.

### EXPIRES_AT

```text
EXPIRES_AT : DATETIME
```

Refresh token expiration date/time.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### REVOKED_AT

```text
REVOKED_AT : DATETIME NULL
```

Date/time when the token was revoked.

Null means that the token has not been explicitly revoked.

### REPLACED_BY_TOKEN_ID

```text
REPLACED_BY_TOKEN_ID : UUID/BIGINT NULL
```

Reference to the refresh token that replaced the current token.

Useful for token rotation.

### CREATED_BY_IP

```text
CREATED_BY_IP : VARCHAR(45)
```

IP address from which the token was created.

### REVOKED_BY_IP

```text
REVOKED_BY_IP : VARCHAR(45) NULL
```

IP address from which the token was revoked.

### USER_AGENT

```text
USER_AGENT : VARCHAR(500) NULL
```

Browser, application, or device user-agent information associated with the token.

---

# 3.15 USER_TOKEN

## Purpose

Stores temporary security/application tokens used for account operations other than the standard refresh-token lifecycle.

Possible token types include:

```text
PASSWORD_RESET
EMAIL_VERIFICATION
PHONE_VERIFICATION
ACCOUNT_ACTIVATION
```

Relationship:

```text
USER_ACCOUNT 1 --- N USER_TOKEN
```

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### USER_ID

```text
USER_ID : UUID/BIGINT
```

Foreign key to `USER_ACCOUNT.ID`.

### TOKEN_TYPE

```text
TOKEN_TYPE : VARCHAR(30)
```

Defines the token purpose.

### TOKEN_HASH

```text
TOKEN_HASH : VARCHAR(255)
```

Hash of the generated temporary token.

The plain token should not be persisted.

### EXPIRES_AT

```text
EXPIRES_AT : DATETIME
```

Token expiration date/time.

### USED_AT

```text
USED_AT : DATETIME NULL
```

Date/time when the token was successfully consumed.

Null indicates that it has not yet been used.

### REQUESTED_BY_IP

```text
REQUESTED_BY_IP : VARCHAR(45) NULL
```

IP address from which the token generation was requested.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Token creation date/time.

---

# 3.16 USER_PREFERENCE

## Purpose

Stores user-specific application preferences and communication choices.

Relationship:

```text
USER_ACCOUNT 1 --- 1 USER_PREFERENCE
```

`USER_ID` is unique according to the current model.

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### USER_ID

```text
USER_ID : UUID/BIGINT
```

Foreign key to `USER_ACCOUNT.ID`.

Must be unique.

### ALLOW_EMAIL

```text
ALLOW_EMAIL : BOOLEAN
```

Indicates whether communication by email is allowed.

### ALLOW_SMS

```text
ALLOW_SMS : BOOLEAN
```

Indicates whether SMS communication is allowed.

### ALLOW_WHATSAPP

```text
ALLOW_WHATSAPP : BOOLEAN
```

Indicates whether WhatsApp communication is allowed.

### ALLOW_PUSH

```text
ALLOW_PUSH : BOOLEAN
```

Indicates whether push notifications are allowed.

### LANGUAGE

```text
LANGUAGE : VARCHAR(10)
```

User's preferred application language.

Example:

```text
pt-BR
en-US
```

### TIME_ZONE

```text
TIME_ZONE : VARCHAR(60)
```

User's preferred time zone.

### THEME

```text
THEME : VARCHAR(30)
```

Preferred application theme.

Examples:

```text
LIGHT
DARK
SYSTEM
```

### DATE_FORMAT

```text
DATE_FORMAT : VARCHAR(20)
```

Preferred date display format.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Creation date/time.

### UPDATED_AT

```text
UPDATED_AT : DATETIME
```

Last update date/time.

---

# 3.17 LOGIN_ATTEMPT

## Purpose

Stores authentication attempts.

This table supports login monitoring, security analysis, account lockout rules, and audit investigation.

The user reference is nullable because a login attempt can fail before a valid user is identified.

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### USER_ID

```text
USER_ID : UUID/BIGINT NULL
```

Foreign key to `USER_ACCOUNT.ID`.

Optional because the submitted username/email may not match any account.

### USERNAME_OR_EMAIL

```text
USERNAME_OR_EMAIL : VARCHAR(180)
```

Login identifier submitted during the authentication attempt.

### IP_ADDRESS

```text
IP_ADDRESS : VARCHAR(45) NULL
```

IP address from which the authentication attempt originated.

### USER_AGENT

```text
USER_AGENT : VARCHAR(500) NULL
```

Browser/device/application information.

### IS_SUCCESS

```text
IS_SUCCESS : BOOLEAN
```

Indicates whether authentication succeeded.

### FAILURE_REASON

```text
FAILURE_REASON : VARCHAR(120) NULL
```

Reason for authentication failure.

Examples may include:

```text
INVALID_PASSWORD
USER_NOT_FOUND
ACCOUNT_LOCKED
ACCOUNT_INACTIVE
```

### ATTEMPTED_AT

```text
ATTEMPTED_AT : DATETIME
```

Date/time when the authentication attempt occurred.

---

# 3.18 AUDIT_LOG

## Purpose

Stores an application audit trail for relevant entity changes and actions.

This table can be used to identify:

- who performed an operation;
- which entity was affected;
- the action executed;
- previous values;
- new values;
- originating IP;
- device/browser;
- correlation identifier.

## Fields

### ID

```text
ID : UUID/BIGINT
```

Primary key.

### USER_ID

```text
USER_ID : UUID/BIGINT NULL
```

Foreign key to `USER_ACCOUNT.ID`.

Nullable so that system-generated or unauthenticated actions can also be recorded.

### ENTITY_NAME

```text
ENTITY_NAME : VARCHAR(120)
```

Name of the affected entity/table/domain object.

Example:

```text
USER_ACCOUNT
PERSON
ROLE
```

### ENTITY_ID

```text
ENTITY_ID : VARCHAR(80)
```

Identifier of the affected entity.

Stored as text to allow logging identifiers from different entity/key strategies.

### ACTION

```text
ACTION : VARCHAR(50)
```

Action performed.

Examples:

```text
CREATE
UPDATE
DELETE
LOGIN
PASSWORD_CHANGE
ROLE_ASSIGNMENT
```

### OLD_VALUES

```text
OLD_VALUES : JSON/TEXT NULL
```

Values before the operation.

Usually populated for update/delete operations.

### NEW_VALUES

```text
NEW_VALUES : JSON/TEXT NULL
```

Values after the operation.

Usually populated for create/update operations.

### IP_ADDRESS

```text
IP_ADDRESS : VARCHAR(45) NULL
```

Originating IP address.

### USER_AGENT

```text
USER_AGENT : VARCHAR(500) NULL
```

Information about the browser, application, or device that generated the action.

### CORRELATION_ID

```text
CORRELATION_ID : VARCHAR(100) NULL
```

Identifier used to correlate multiple records/logs belonging to the same request or distributed operation.

### CREATED_AT

```text
CREATED_AT : DATETIME
```

Date/time when the audit event was recorded.

---

# 4. Main Relationships

The main relationships defined by the current model are:

```text
ORGANIZATION 1 ---- N USER_GROUP

ORGANIZATION 1 ---- N ROLE

USER_GROUP 1 ---- N USER_ACCOUNT

PERSON 1 ---- 0..1 USER_ACCOUNT

PERSON 1 ---- N PERSON_DOCUMENT

PERSON 1 ---- N PERSON_CONTACT

CONTACT_TYPE 1 ---- N PERSON_CONTACT

PERSON 1 ---- N ADDRESS

USER_ACCOUNT N ---- N ROLE
    through USER_ROLE

ROLE N ---- N PERMISSION
    through ROLE_PERMISSION

RESOURCE 1 ---- N PERMISSION

RESOURCE 1 ---- N RESOURCE
    through PARENT_RESOURCE_ID

USER_ACCOUNT 1 ---- N REFRESH_TOKEN

USER_ACCOUNT 1 ---- N USER_TOKEN

USER_ACCOUNT 1 ---- 1 USER_PREFERENCE

USER_ACCOUNT 1 ---- N LOGIN_ATTEMPT

USER_ACCOUNT 1 ---- N AUDIT_LOG
```

---

# 5. Authentication Flow

The authentication-related model is centered on:

```text
USER_ACCOUNT
REFRESH_TOKEN
USER_TOKEN
LOGIN_ATTEMPT
```

Expected responsibilities:

### USER_ACCOUNT

Stores user credentials and security state.

### REFRESH_TOKEN

Supports session renewal / JWT refresh-token rotation.

### USER_TOKEN

Supports temporary flows such as:

```text
password recovery
email verification
phone verification
account activation
```

### LOGIN_ATTEMPT

Records successful and failed authentication attempts.

---

# 6. Authorization Flow

Authorization uses an RBAC-style model.

Structure:

```text
USER_ACCOUNT
      |
      N
      |
USER_ROLE
      |
      N
      |
ROLE
      |
      N
      |
ROLE_PERMISSION
      |
      N
      |
PERMISSION
      |
      N
      |
RESOURCE
```

Example:

```text
ROLE = ADMIN

RESOURCE = USER

PERMISSION = USER_READ
PERMISSION = USER_CREATE
PERMISSION = USER_UPDATE
PERMISSION = USER_DELETE
```

This allows access to be controlled at a resource/action level rather than hardcoding authorization rules directly into a user record.

---

# 7. Person Registration Structure

The personal registration domain is composed of:

```text
PERSON
PERSON_DOCUMENT
CONTACT_TYPE
PERSON_CONTACT
ADDRESS
```

This avoids creating a large `PERSON` table with multiple repeated fields such as:

```text
PHONE_1
PHONE_2
EMAIL_1
EMAIL_2
ADDRESS_1
ADDRESS_2
DOCUMENT_1
DOCUMENT_2
```

Instead, child tables support multiple records naturally.

---

# 8. Soft Delete

Tables containing:

```text
DELETED_AT
```

must use logical deletion whenever required by the application.

A standard query should normally filter:

```sql
DELETED_AT IS NULL
```

unless deleted records are explicitly requested for administrative or audit purposes.

---

# 9. Suggested Uniqueness Rules from the Current Model

The current diagram explicitly marks the following fields as unique:

```text
ORGANIZATION.CODE
ORGANIZATION.TAX_ID

USER_GROUP.CODE

USER_ACCOUNT.PERSON_ID
USER_ACCOUNT.USERNAME
USER_ACCOUNT.EMAIL

ROLE.CODE

PERMISSION.CODE

RESOURCE.CODE

USER_PREFERENCE.USER_ID
```

These uniqueness constraints must be reflected in database migrations.

---

# 10. Security Requirements

The implementation must respect the following model implications:

1. Never persist plain-text passwords.
2. Persist only `PASSWORD_HASH`.
3. Persist refresh and temporary tokens as hashes in `TOKEN_HASH`.
4. Track invalid login attempts.
5. Support temporary account lockout through `LOCKED_UNTIL`.
6. Support forced password change through `MUST_CHANGE_PASSWORD`.
7. Support two-factor authentication state through `TWO_FACTOR_ENABLED`.
8. Record security-relevant events through `LOGIN_ATTEMPT` and/or `AUDIT_LOG`.
9. Allow token revocation and refresh-token rotation.
10. Use `EMAIL_VERIFIED_AT`, `PHONE_VERIFIED_AT`, and contact verification fields to track verification state.

---

# 11. Expected Implementation

The task is considered complete when the application/database layer contains the equivalent of the following entities:

```text
ORGANIZATION
USER_GROUP
PERSON
USER_ACCOUNT
PERSON_DOCUMENT
CONTACT_TYPE
PERSON_CONTACT
ADDRESS
ROLE
RESOURCE
PERMISSION
USER_ROLE
ROLE_PERMISSION
REFRESH_TOKEN
USER_TOKEN
USER_PREFERENCE
LOGIN_ATTEMPT
AUDIT_LOG
```

The implementation must preserve the relationships, field purposes, uniqueness rules, and authentication/authorization responsibilities described in this document.

---

# 12. Summary

The model is divided into six main areas:

```text
Organization
    ORGANIZATION
    USER_GROUP

Person
    PERSON
    PERSON_DOCUMENT
    CONTACT_TYPE
    PERSON_CONTACT
    ADDRESS

Authentication
    USER_ACCOUNT
    REFRESH_TOKEN
    USER_TOKEN
    LOGIN_ATTEMPT

Authorization
    ROLE
    PERMISSION
    RESOURCE
    USER_ROLE
    ROLE_PERMISSION

Preferences
    USER_PREFERENCE

Auditing
    AUDIT_LOG
```

This separation keeps personal information, authentication, authorization, preferences, security, and auditing isolated while maintaining clear relationships between them.
