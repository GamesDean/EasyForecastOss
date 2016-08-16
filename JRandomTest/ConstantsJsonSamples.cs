namespace EasyForecast.SymEngine.Json.Tests
{
    public static class ConstantsJsonSamples
    {
        public static readonly string JsonSampleInputData1 = @"
        {
            'FECs': [{
                'FecName': 'FecNameXYZ',
                'FecId': 1,
                'OrderedParameterNames': ['NumArrayNameXYZ1', 'StrArrayNameXYZ1', 'NumArrayNameXYZ2', '...and other parameter names...'],
                'NumParameters': [{
                    'ArrayName': 'NumArrayNameXYZ1',
                    'ArrayContent': [1, 2, 3, 4, 5, 6, 7, 8, 9]
                }, {
                    'ArrayName': 'NumArrayNameXYZ2',
                    'ArrayContent': [9, 8, 7, 6, 5, 4, 3, 2, 1]
                }, {
                    'ArrayName': 'NumArrayNameXYZ3',
                    'ArrayContent': [5, 4, 3, 2, 1, 9, 8, 7, 6]
                }],
                'StrParameters': [{
                    'ArrayName': 'StrArrayNameXYZ1',
                    'ArrayContent': ['a', 'b', 'c']
                }, {
                    'ArrayName': 'StrArrayNameXYZ2',
                    'ArrayContent': ['a', 'b', 'c']
                }, {
                    'ArrayName': 'StrArrayNameXYZ3',
                    'ArrayContent': ['a', 'b', 'c']
                }],
                'DateParameters': [{
                    'ArrayName': 'DateArrayNameXYZ1',
                    'ArrayContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }, {
                    'ArrayName': 'DateArrayNameXYZ2',
                    'ArrayContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }, {
                    'ArrayName': 'DateArrayNameXYZ3',
                    'ArrayContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }],
                'FmlNumParameters': [{
                    'ArrayName': 'FmlNumArrayNameXYZ1',
                    'ArrayContent': [1, 2, 3]
                }, {
                    'ArrayName': 'FmlNumArrayNameXYZ2',
                    'ArrayContent': [1, 2, 3]
                }, {
                    'ArrayName': 'FmlNumArrayNameXYZ3',
                    'ArrayContent': [1, 2, 3]
                }],
                'FmlStrParameters': [{
                    'ArrayName': 'FmlStrArrayNameXYZ1',
                    'ArrayContent': ['a', 'b', 'c']
                }, {
                    'ArrayName': 'FmlStrArrayNameXYZ2',
                    'ArrayContent': ['a', 'b', 'c']
                }, {
                    'ArrayName': 'FmlStrArrayNameXYZ3',
                    'ArrayContent': ['a', 'b', 'c']
                }],
                'FmlDateParameters': [{
                    'ArrayName': 'FmlDateArrayNameXYZ1',
                    'ArrayContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }, {
                    'ArrayName': 'FmlDateArrayNameXYZ2',
                    'ArrayContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }, {
                    'ArrayName': 'FmlDateArrayNameXYZ3',
                    'ArrayContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }]
            }]
        }
            ";

        public static readonly string JsonSampleOutputData1 = @"
        {
            'Tables': [{
                'TableName': 'FecNameXYZ',
                'TableId': 1,
                'OrderedColumnNames': ['NumColumnNameXYZ1', 'StrColumnNameXYZ1', 'NumColumnNameXYZ2', '...and other column names...'],
                'NumColumns': [{
                    'ColumnName': 'NumColumnNameXYZ1',
                    'ColumnContent': [10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                }, {
                    'ColumnName': 'NumColumnNameXYZ2',
                    'ColumnContent': [15, 14, 13, 12, 11, 10, 19, 18, 17, 16]
                }, {
                    'ColumnName': 'NumColumnNameXYZ3',
                    'ColumnContent': [99, 98, 97, 96, 95, 94 ,93, 92, 91, 90]
                }],
                'StrColumns': [{
                    'ColumnName': 'StrColumnNameXYZ1',
                    'ColumnContent': ['a', 'b', 'c']
                }, {
                    'ColumnName': 'StrColumnNameXYZ2',
                    'ColumnContent': ['a', 'b', 'c']
                }, {
                    'ColumnName': 'StrColumnNameXYZ3',
                    'ColumnContent': ['a', 'b', 'c']
                }],
                'DateColumns': [{
                    'ColumnName': 'DateColumnNameXYZ1',
                    'ColumnContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }, {
                    'ColumnName': 'DateColumnNameXYZ2',
                    'ColumnContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }, {
                    'ColumnName': 'DateColumnNameXYZ3',
                    'ColumnContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }]
            }]
        }
            ";

    }
}
