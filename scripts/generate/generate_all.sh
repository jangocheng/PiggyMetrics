set -ex

cd $(dirname $0)/../../src

PROTOC=protoc
PLUGIN=protoc-gen-dotbpe=../tools/protoc_plugin/Protobuf.Gen.exe
OUT_DIR=./PiggyMetrics.Common/_g
PROTO_DIR=./protos

$PROTOC  -I=$PROTO_DIR --csharp_out=$OUT_DIR --dotbpe_out=$OUT_DIR --plugin=$PLUGIN \
    $PROTO_DIR/{dotbpe_option,message}.proto  $PROTO_DIR/services/{auth,account,statistics}.proto
