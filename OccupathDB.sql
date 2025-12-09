USE db_occupath;
GO

-- 1. HAPUS FOREIGN KEY CONSTRAINTS
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Student_User')
    ALTER TABLE student_profiles DROP CONSTRAINT FK_Student_User;

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Academic_User')
    ALTER TABLE academic_data DROP CONSTRAINT FK_Academic_User;

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Character_User')
    ALTER TABLE character_data DROP CONSTRAINT FK_Character_User;

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Recommendation_User')
    ALTER TABLE recommendations DROP CONSTRAINT FK_Recommendation_User;
GO

-- 2. HAPUS TABEL LAMA
DROP TABLE IF EXISTS recommendations;
DROP TABLE IF EXISTS rules;
DROP TABLE IF EXISTS character_data;
DROP TABLE IF EXISTS academic_data;
DROP TABLE IF EXISTS student_profiles;
DROP TABLE IF EXISTS users;
GO

-- 3. BUAT TABEL BARU

-- Table Users
CREATE TABLE users (
    id_user INT IDENTITY(1,1) PRIMARY KEY, -- sudah auto increment
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    nama_lengkap VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Table Student Profiles
CREATE TABLE student_profiles (
    id_profile INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL UNIQUE,
    jenis_kelamin CHAR(1) NOT NULL, -- 'L' / 'P'
    status_pendidikan VARCHAR(20),
    program_studi VARCHAR(50),
    semester INT,
    status_mahasiswa VARCHAR(20),
    latar_belakang VARCHAR(50),
    alasan_memilih_prodi VARCHAR(50),
    tujuan_kuliah VARCHAR(50),
    metode_belajar VARCHAR(50),
    motivasi_belajar VARCHAR(20), 
    created_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Student_User FOREIGN KEY (id_user) REFERENCES users(id_user)
);
GO

-- Table Pertanyaan
CREATE TABLE questions (
    id_question INT IDENTITY(1,1) PRIMARY KEY,
    question_code VARCHAR(10) NOT NULL UNIQUE, -- ini kode fakta: F_B1, F_C56, ...
    question_text VARCHAR(500) NOT NULL, -- text pertanyaan yg ditampilkan
    category VARCHAR(20) NOT NULL,  -- 'A' atau 'B' atau 'C'
    subcategory VARCHAR(50),   -- Analytical, Technical, ...
    created_at DATETIME DEFAULT GETDATE()
);
GO

-- Table Jawaban User (Untuk kategori B & C – CF Evidence)
CREATE TABLE user_answers (
    id_answer INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    question_code VARCHAR(10) NOT NULL,
    answer_scale INT CHECK (answer_scale BETWEEN 1 AND 5),
    cf_value DECIMAL(3,2) DEFAULT 0.0,
    answered_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Answer_User FOREIGN KEY (id_user) REFERENCES users(id_user),
    CONSTRAINT FK_Answer_Question FOREIGN KEY (question_code) REFERENCES questions(question_code)
);

-- Table Graduate Profiles 
CREATE TABLE graduate_profiles (
    id_profile INT IDENTITY(1,1) PRIMARY KEY,
    profile_code VARCHAR(10) NOT NULL UNIQUE,
    profile_name VARCHAR(50) NOT NULL,
    description NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE()
);
GO

-- Table Rules (IF-THEN + CF_Rule)
CREATE TABLE rules (
    id_rule INT IDENTITY(1,1) PRIMARY KEY,
    rule_code VARCHAR(10) NOT NULL UNIQUE, -- R_FE1, R_BE1, dst.
    profile_code VARCHAR(10) NOT NULL, -- ngelead ke profil mana
    premises_json NVARCHAR(MAX) NOT NULL,
    cf_rule DECIMAL(3,2) NOT NULL CHECK (cf_rule BETWEEN 0 AND 1),
    created_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Rule_Profile FOREIGN KEY (profile_code) REFERENCES graduate_profiles(profile_code)
);
GO
-- contoh value premises_json:
-- [
--   {"code": "F_B1", "op": ">=", "value": 4},
--   {"code": "F_C7", "op": ">=", "value": 3},
--   {"code": "MAJOR", "op": "=",  "value": "TI"}
-- ]

-- 7. Table Rekomendasi Hasil
CREATE TABLE recommendations (
    id_recommendation INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    profile_code VARCHAR(10) NOT NULL,
    cf_total DECIMAL(5,4) NOT NULL,  -- cf final setelah modifier
    calculated_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Recommend_User FOREIGN KEY (id_user) REFERENCES users(id_user),
    CONSTRAINT FK_Recommend_Profile FOREIGN KEY (profile_code) REFERENCES graduate_profiles(profile_code)
);
GO

-- 8. Table Modifier (Kategori A → pengaruh ke profil)
CREATE TABLE profile_modifiers (
    id_modifier INT IDENTITY(1,1) PRIMARY KEY,
    profile_code VARCHAR(10) NOT NULL,
    condition_column VARCHAR(50),  -- kolom di student_profiles yang akan di cek
    condition_value VARCHAR(100), -- nilai yang memicu
    modifier_factor DECIMAL(3,2) NOT NULL,  -- contoh: 1.1 (naik 10%), 0.9 (turun 10%)
    notes VARCHAR(255),
    CONSTRAINT FK_Modifier_Profile FOREIGN KEY (profile_code) REFERENCES graduate_profiles(profile_code)
);
GO

PRINT 'Database db_occupath berhasil diupdate';