# Manajemen Alat Laboratorium API

- [Alat API](#alat-api)
    - [Create Alat](#create-alat)
        - [Create Alat Request](#create-alat-request)
        - [Create Alat Response](#create-alat-response)
    - [Get Alat](#get-alat)
        - [Get Alat Request](#get-alat-request)
        - [Get Alat Response](#get-alat-response)
    - [Update Alat](#update-alat)
        - [Update Alat Request](#update-alat-request)
        - [Update Alat Response](#update-alat-response)
    - [Delete Alat](#delete-alat)
        - [Delete Alat Request](#delete-alat-request)
        - [Delete Alat Response](#delete-alat-response)
- [Peminjam API](#peminjam-api)
    - [Create Peminjam](#create-peminjam)
        - [Create Peminjam Request](#create-peminjam-request)
        - [Create Peminjam Response](#create-peminjam-response)
    - [Get Peminjam](#get-product)
        - [Get Peminjam Request](#get-peminjam-request)
        - [Get Peminjam Response](#get-peminjam-response)
    - [Update Peminjam](#update-peminjam)
        - [Update Peminjam Request](#update-peminjam-request)
        - [Update Peminjam Response](#update-peminjam-response)
- [Peminjaman Alat API](#peminjaman-alat-api)
    - [Create Peminjaman Alat](#create-peminjaman-alat)
        - [Create Peminjaman Alat Request](#create-peminjaman-alat-request)
        - [Create Peminjaman Alat Response](#create-peminjaman-alat-response)
    - [Get Peminjaman Alat](#get-peminjaman-alat)
        - [Get Peminjaman Alat Request](#get-peminjaman-alat-request)
        - [Get Peminjaman Alat Response](#get-peminjaman-alat-response)
    - [Update Peminjaman Alat](#update-peminjaman-alat)
        - [Update Peminjaman Alat Request](#update-peminjaman-alat-request)
        - [Update Peminjaman Alat Response](#update-peminjaman-alat-response)
    - [Delete Peminjaman Alat](#delete-peminjaman-alat)
        - [Delete Peminjaman Alat Request](#delete-peminjaman-alat-request)
        - [Delete Peminjaman Alat Response](#delete-peminjaman-alat-response)

## Alat API

### Create Alat

#### Create Alat Request

```js
POST /api/alat
```

```json
{
    "nama": "Lampu Spirtus",
    "deskripsi": "Lampu pemanas api dengan bahan bakar dari spirtus",
    "total": 10
}
```

#### Create Alat Response

```js
201 Created
```

```yml
Location: {{host}}/api/alat/{{id}}
```

```json
{
    "id": 1,
    "nama": "Lampu Spirtus",
    "deskripsi": "Lampu pemanas api dengan bahan bakar dari spirtus",
    "total": 10
}
```

### Get Alat

#### Get Alat Request

```js
GET /api/alat
```

or

```js
GET /api/alat/{{id}}
```

#### Get Alat Response

```js
200 OK
```

```json
{
    "id": 1,
    "nama": "Lampu Spirtus",
    "deskripsi": "Lampu pemanas api dengan bahan bakar dari spirtus",
    "total": 10
}
```

### Update Alat

#### Update Alat Request

```js
PUT /api/alat/{{id}}
```

```json
{
    "nama": "Lampu Spirtus",
    "deskripsi": "Lampu pemanas api berbahan bakar spirtus",
    "total": 25
}
```

#### Update Alat Response

```js
204 No Content
```

### Delete Alat

#### Delete Alat Request

```js
DELETE /api/alat/{{id}}
```

#### Delete Alat Response

```js
204 No Content
```

## Peminjam API

### Create Peminjam

#### Create Peminjam Request

```js
POST /api/peminjam
```

```json
{
    "nama": "Dani Gelen",
    "email": "danigelen@gmail.com",
    "alamat": "Jl Lengkok Raya, Pancor, Jawa Barat",
    "nomorhandphone": "085913245921",
    "aktif": true
}
```

#### Create Peminjam Response

```js
201 Created
```

```yml
Location: {{host}}/api/peminjam/{{id}}
```

```json
{
    "id": 1,
    "nama": "Dani Gelen",
    "alamat": "Jl Lengkok Raya, Pancor, Jawa Barat",
    "email": "danigelen@gmail.com",
    "nomorhandphone": "085913245921",
    "aktif": true
}
```

### Get Peminjam

#### Get Peminjam Request

```js
GET /api/peminjam
```

or

```js
GET /api/peminjam/{{id}}
```

#### Get Peminjam Response

```js
200 OK
```

```json
{
    "id": 1,
    "nama": "Dani Gelen",
    "email": "danigelen@gmail.com",
    "alamat": "Jl Lengkok Raya, Pancor, Jawa Barat",
    "nomorhandphone": "085913245921",
    "aktif": true
}
```

### Update Peminjam

#### Update Peminjam Request

```js
PUT /api/peminjam/{{id}}
```

```json
{
    "nama": "Dani Pasti Gelen",
    "email": "danigelengelen@gmail.com",
    "alamat": "Jl Lengkok Raya, Pancor, Sumatera Timur",
    "nomorhandphone": "085913245921",
    "aktif": true
}
```

#### Update Peminjam Response

```js
204 No Content
```

## Peminjaman Alat API

### Create Peminjaman Alat

#### Create Peminjaman Alat Request

```js
POST /api/peminjaman-alat
```

##### Create Peminjaman with Tanggal Peminjaman Default (DateTime Now)

```json
{
    "peminjamId": 1,
    "detailPeminjamanAlat": 
    [
        {
            "alatId": 1,
            "jumlah": 2
        },
        {
            "alatId": 2,
            "jumlah": 4
        }
    ]
}
```

or

##### Create Peminjaman with Tanggal Peminjaman

```json
{
    "tanggalPeminjaman": "2023-08-29T08:00:00",
    "peminjamId": 1,
    "detailPeminjamanAlat": 
    [
        {
            "alatId": 1,
            "jumlah": 2
        },
        {
            "alatId": 2,
            "jumlah": 4
        }
    ]
}
```

#### Create Peminjaman Alat Response

```js
201 Created
```

```yml
Location: {{host}}/api/peminjaman-alat/{{id}}
```

```json
{
  "id": 1,
  "tanggalPeminjaman": "2023-08-29T08:00:00",
  "tanggalPengembalian": "2023-09-05T09:59:32.6027367",
  "dikembalikanPadaTanggal": null,
  "peminjam": {
    "id": 1,
    "nama": "Dani Pasti Gelen",
    "email": "danigelengelen@gmail.com",
    "alamat": "Jl Lengkok Raya, Pancor, Sumatera Timur",
    "nomorhandphone": "085913245921",
    "aktif": true
  },
  "detailPeminjamanAlat": [
    {
      "id": 1,
      "jumlahDipinjam": 2,
      "alat": {
        "id": 1,
        "namaAlat": "Lampu Spirtus",
        "deskripsi": "Lampu pemanas api berbahan bakar spirtus"
      }
    },
    {
      "id": 2,
      "jumlahDipinjam": 4,
      "alat": {
        "id": 2,
        "namaAlat": "Beaker Gelas",
        "deskripsi": "Beaker gelas untuk menampung sample / bahan sementara"
      }
    }
  ]
}
```

### Get Peminjaman Alat

#### Get Peminjaman Alat Request

```js
GET /api/peminjaman-alat
```

or

```js
GET /api/peminjaman-alat/{{id}}
```

#### Get Peminjaman Alat Response

```js
200 OK
```

```json
{
  "id": 1,
  "tanggalPeminjaman": "2023-08-29T08:00:00",
  "tanggalPengembalian": "2023-09-05T09:59:32.6027367",
  "dikembalikanPadaTanggal": null,
  "peminjam": {
    "id": 1,
    "nama": "Dani Pasti Gelen",
    "email": "danigelengelen@gmail.com",
    "alamat": "Jl Lengkok Raya, Pancor, Sumatera Timur",
    "nomorhandphone": "085913245921",
    "aktif": true
  },
  "detailPeminjamanAlat": [
    {
      "id": 1,
      "jumlahDipinjam": 2,
      "alat": {
        "id": 1,
        "namaAlat": "Lampu Spirtus",
        "deskripsi": "Lampu pemanas api berbahan bakar spirtus"
      }
    },
    {
      "id": 2,
      "jumlahDipinjam": 4,
      "alat": {
        "id": 2,
        "namaAlat": "Beaker Gelas",
        "deskripsi": "Beaker gelas untuk menampung sample / bahan sementara"
      }
    }
  ]
}
```

### Update Peminjaman Alat

#### Update Peminjaman Alat Request

```js
PUT /api/peminjaman-alat/{{id}}
```

##### Update Pengembalian

```json
{
    "dikembalikanPadaTanggal": "2023-08-25T08:00:00",
}
```

or

##### Update Tanggal Peminjaman, Peminjam and Detail Peminjaman Alat

```json
{
    "tanggalPeminjaman": "2023-08-18T13:24:00",
    "peminjamId": 2,
    "detailPeminjamanAlat": 
    [
        {
            "alatId": 1,
            "jumlah": 3
        },
        {
            "alatId": 2,
            "jumlah": 3
        }
    ]
}
```

or

##### Update Tanggal Peminjaman, Pengembalian, Peminjam and Detail Peminjaman Alat

```json
{
    "tanggalPeminjaman": "2023-08-18T13:24:00",
    "dikembalikanPadaTanggal": null,
    "peminjamId": 2,
    "detailPeminjamanAlat": 
    [
        {
            "alatId": 1,
            "jumlah": 3
        },
        {
            "alatId": 2,
            "jumlah": 3
        }
    ]
}
```

#### Update Peminjaman Alat Response

```js
204 No Content
```

### Delete Peminjaman Alat

#### Delete Peminjaman Alat Request

```js
DELETE /api/peminjaman-alat/{{id}}
```

#### Delete Peminjaman Alat Response

```js
204 No Content
```